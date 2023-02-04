using System.Text;
using System.Text.Json.Serialization;
using DefaultTemplate.Common.Enums;
using DefaultTemplate.Common.Exceptions;
using DefaultTemplate.DataAccess;
using DefaultTemplate.DI;
using DefaultTemplate.Domain.Models.Bussineses;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Models.Waiters;
using DefaultTemplate.Domain.Options;
using DefaultTemplate.Domain.Services.Bussineses;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.Users;
using DefaultTemplate.Domain.Services.Waiters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) =>
    lc.ReadFrom.Configuration(builder.Configuration, "Serilog").Enrich.WithProperty("app-name", "main-api"));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Waiters Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.OperationFilter<SwaggerFileOperationFilter>();

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("Smtp"));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DefaultContext>(optionsBuilder => { optionsBuilder.UseNpgsql(connection); });

builder.Services.AddHealthChecks();
builder.Services.AddCommonServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Api", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DefaultContext>();
    context.Database.Migrate();
    
    new DataInitializer(scope.ServiceProvider).Init().GetAwaiter().GetResult();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials());

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var contextService = context.RequestServices.GetRequiredService<IContextService>() as HttpContextService;
    var userService = context.RequestServices.GetRequiredService<IUserService>();
    var waiterService = context.RequestServices.GetRequiredService<IWaiterService>();
    var bussinesService = context.RequestServices.GetRequiredService<IBussinessService>();

    var claim = context.User.Claims;
    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    if (token != null)
    {
        var mail = contextService.ValidateToken(token);
        if (mail != null)
        {
            contextService.CurrentUser = await userService.FirstOrDefault(new UserQuery(){Mail = mail});
            var waiter = await waiterService.FirstOrDefault(new WaiterQuery() { Mail = mail });
            if (waiter != null)
            {
                contextService.CurrentWaiter = waiter;
                contextService.CurrentBussiness = null;
                contextService.isBussiness = false;
            }
            var business = await bussinesService.FirstOrDefault(new BussinessQuery() { Mail = mail });
            if (business != null)
            {
                contextService.CurrentWaiter = null;
                contextService.CurrentBussiness = business;
                contextService.isBussiness = true;     
            }

        }
    }

    await next(context);
});

app.MapControllers()
    .RequireAuthorization("Api");

app.UseExceptionHandler(applicationBuilder =>
{
    applicationBuilder.Run(async context =>
    {
        var handlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (handlerFeature?.Error is ExecutionResultException exception)
        {
            context.Response.ContentType = "application/json";

            var status = exception.Code switch
            {
                DefaultResult.IncorrectData => 400,
                _ => 500
            };

            context.Response.StatusCode = status;

            await context.Response.WriteAsJsonAsync(new
            {
                Code = exception.Code,
                Message = exception.Message,
                Field = exception.Field
            });
        }
        else
        {
            throw handlerFeature?.Error!;
        }
    });
});

app.Run();


public class SwaggerFileOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileUploadMime = "multipart/form-data";
        if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
            return;

        var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
        operation.RequestBody.Content[fileUploadMime].Schema.Properties =
            fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
            {
                Type = "string",
                Format = "binary"
            });
    }
}
