using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Gbim.Notification.Client.ApiClient;
using Gbim.Shared.Constant;
using Gbim.Shared.Http.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gbim.Notification.Client
{
    public static class DependencyInjection {
        public static void AddNotificationService(this IServiceCollection services) {
            services.AddOptions();
            services
                .AddHttpClient(ConfigSection.NOTIFICATION_API, (provider, client) => {
                    var serviceOptions = provider.GetRequiredService<NotificationApiOptions>();
                    client.BaseAddress = new Uri(serviceOptions.ApiEndpoint);
                    client.Timeout = TimeSpan.FromSeconds(serviceOptions.TimeoutInSeconds);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpLoggingHandler(new HttpClientHandler() {
                    ServerCertificateCustomValidationCallback =
                        (message, certificate, chain, sslPolicyErrors) => true
                }));

            services.AddScoped<INotificationApiClient, NotificationApiClient>();
        }
    }
}
