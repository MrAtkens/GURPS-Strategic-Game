using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Gbim.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.CreateText("serilog.self.log");
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Gbim.Gateway service stopped");
                file.WriteLine("Startup error: " + e.Message + "\r\n" + e.StackTrace);
                throw;
            }
            finally
            {
                Serilog.Log.CloseAndFlush();
                file.Dispose();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => {
                    var path = Environment.GetEnvironmentVariable("CONF_PATH") ?? "Default";
                    var env = hostingContext.HostingEnvironment;
                    config
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config
                        .AddJsonFile($"RouteSettings/{path}/ocelot.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"RouteSettings/{path}/ocelot.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder
                        .ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders())
                        .UseSerilog(ConfigureLogger)
                        .UseStartup<Startup>()
                        .UseKestrel(x => {
                            x.AllowSynchronousIO = true;
                            x.Limits.MaxRequestBodySize = 4294967296;
                        });
                });

        private static void ConfigureLogger(WebHostBuilderContext context, LoggerConfiguration config)
        {
            config
                .ReadFrom.Configuration(context.Configuration)
                .Enrich.WithProperty("app-name", "gbim-gateway-api")
                .Enrich.WithClientIp()
                .Enrich.WithClientAgent()
                .Enrich.FromLogContext();
        }
    }
}
