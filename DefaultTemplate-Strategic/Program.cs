using System.Security.Claims;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using System.Text.Json.Serialization;
using DefaultTemplate.DataAccess;
using DefaultTemplate.Domain.Services.System;
using DefaultTemplate.Common.Exceptions;
using DefaultTemplate.Common.Enums;
using DefaultTemplate.DI;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(builder.Configuration, "Serilog"));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Strategic Api", Version = "v1" });
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

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DefaultContext>(optionsBuilder => { optionsBuilder.UseNpgsql(connection); });
builder.Services.AddDefaultServices();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = builder.Configuration["Oidc:Authority"];
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DefaultContext>();
    context.Database.Migrate();

    new DataInitializer(scope.ServiceProvider).Init().GetAwaiter().GetResult();
}


app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

/*app.Use(async (context, next) =>
{
    var contextService = context.RequestServices.GetRequiredService<IContextService>() as HttpContextService;
    var natPersonService = context.RequestServices.GetRequiredService<INatPersonService>();

    var claim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
    var claimActivity = context.User.Claims.FirstOrDefault(x => x.Type == "activities");
    var claimUnitType = context.User.Claims.FirstOrDefault(x => x.Type == "unitType");

    await next();
});*/

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
            await context.Response.WriteAsJsonAsync(new
            {
                Code = 500,
                Message = handlerFeature?.Error.InnerException?.Message ?? handlerFeature?.Error.Message
            });
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