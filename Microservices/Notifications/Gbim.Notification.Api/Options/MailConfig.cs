
namespace Gbim.Notification.Api.Options {
    public class MailConfig {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Ssl { get; set; }
        public int Timeout { get; set; }
    }
}
