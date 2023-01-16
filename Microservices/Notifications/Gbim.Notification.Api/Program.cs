using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Gbim.Notification.Api {
    public class Program {
        public static void Main(string[] args) {
            var file = File.CreateText("serilog.self.log");
            try {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e) {
                Log.Fatal(e, "Notification service stopped");
                throw;
            }
            finally {
                Serilog.Log.CloseAndFlush();
                file.Dispose();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder
                        .ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders())
                        .UseSerilog(ConfigureLogger)
                        .ConfigureKestrel(x => x.AllowSynchronousIO = true)
                        .UseStartup<Startup>();
                });

        private static void ConfigureLogger(WebHostBuilderContext context, LoggerConfiguration config) {
            config
                .ReadFrom.Configuration(context.Configuration)
                // TODO: указать наименование приложения для логгирования
                .Enrich.WithProperty("app-name", "gbim-notification-client")
                .Enrich.FromLogContext();
        }
    }
}