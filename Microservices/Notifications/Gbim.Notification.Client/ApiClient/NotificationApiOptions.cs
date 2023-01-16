using System;
using System.Collections.Generic;
using System.Text;

namespace Gbim.Notification.Client.ApiClient
{
    public class NotificationApiOptions {
        public string ApiEndpoint { get; set; }
        public int TimeoutInSeconds { get; set; }
    }
}
