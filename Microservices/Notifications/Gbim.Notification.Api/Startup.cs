using System.Text.Json;
using AutoMapper;
using Gbim.Notification.Api.Message;
using Gbim.Notification.Api.Options;
using Gbim.Notification.Api.Senders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NCANodeApi.Client;
using Serilog;

namespace Gbim.Notification.Api {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddOptions();
            ConfigureOptions(services);

            services.AddAutoMapper((provider, config) => { }, typeof(Startup));
            services
                .AddControllers()
                .AddJsonOptions(opt => {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddSwaggerGen(cfg => {
                cfg.EnableAnnotations();
            });
            services.AddScoped<MessageFactory>();
            services.AddScoped<EmailSender>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, IHostApplicationLifetime applicationLifetime, IBusControl bus*/) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gbim.Notification.Api");
                c.RoutePrefix = string.Empty;
            });
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureOptions(IServiceCollection services) {
            services.Configure<KestrelServerOptions>(options => Configuration.GetSection("Kestrel").Bind(options));
            services.AddSingleton(x => x.GetService<IOptions<KestrelServerOptions>>().Value);
            services.Configure<MailConfig>(options => Configuration.GetSection("Smtp").Bind(options));
            services.AddSingleton(x => x.GetService<IOptions<MailConfig>>().Value);
            DependencyInjection.AddNcaNodeApiClient(services, Configuration);
        }
    }
}