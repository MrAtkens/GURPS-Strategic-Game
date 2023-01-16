using System;
using System.Diagnostics;
using System.Net.Http;
using Gbim.Shared.Constant;
using Gbim.Gateway.Services;
using Gbim.Gateway.Settings;
using Gbim.Shared.Http.OIDC;
using Gbim.Shared.Http.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Refit;
using Serilog;

namespace Gbim.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureOptions(services);
            services.AddControllers();
            services.AddOcelot()
                .AddDelegatingHandler<HttpLoggingHandler>();
            services.AddSsoAuthentication(Configuration);
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddHttpContextAccessor();

            var customSettings = Configuration.GetSection(ConfigSection.CUSTOM_SETTINGS).Get<CustomSettings>();
            if (customSettings.EnableTracing)
            {
                var listener = new SerilogTraceListener.SerilogTraceListener();
                Trace.Listeners.Add(listener);
            }
            services.AddMemoryCache();
            this.RegisterWebServices(services);
            services.AddSwaggerForOcelot(Configuration);
            services.AddHealthChecks();
        }

        /// <summary>  Web-services registration with Refit </summary>
        private void RegisterWebServices(IServiceCollection services)
        {
            var refitSettings = new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            };
            services.AddRefitClient<IProfileService>(refitSettings)
                .ConfigureHttpClient(((provider, client) => {
                    var options = provider.GetRequiredService<AccountApiOptions>();
                    client.BaseAddress = new Uri(options.ApiEndpoint);
                    client.Timeout = TimeSpan.FromSeconds(options.TimeoutInSeconds);
                }))
                .ConfigurePrimaryHttpMessageHandler(() => {
                    return new HttpLoggingHandler(new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback =
                            (message, certificate, chain, sslPolicyErrors) => true
                    });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CustomSettings customSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            if (customSettings.EnableTracing)
            {
                app.UseSerilogRequestLogging(options =>
                    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) => {
                        var request = httpContext.Request;
                        diagnosticContext.Set("Host", request.Host);
                        diagnosticContext.Set("Protocol", request.Protocol);
                        diagnosticContext.Set("Scheme", request.Scheme);
                        if (request.QueryString.HasValue)
                        {
                            diagnosticContext.Set("QueryString", request.QueryString.Value);
                        }
                        diagnosticContext.Set("ContentType", httpContext.Response.ContentType);
                    });
            }

            app.UseCors("CorsPolicy");
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context => {
                    context.Context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                }
            });

            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseOcelot().Wait();
        }

        private void ConfigureOptions(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<AccountApiOptions>(options => this.Configuration.GetSection(ConfigSection.ACCOUNT_API).Bind(options));
            services.AddSingleton(x => x.GetService<IOptions<AccountApiOptions>>().Value);

            services.Configure<CustomSettings>(options => this.Configuration.GetSection(ConfigSection.CUSTOM_SETTINGS).Bind(options));
            services.AddSingleton(x => x.GetService<IOptions<CustomSettings>>().Value);
        }
    }
}
