using Gbim.Notification.Api.Abstract;
using Gbim.Notification.Api.Message;
using Gbim.Notification.Api.Options;
using Gbim.Notification.Client.DTO;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Gbim.Shared.DataContracts;
using Microsoft.Extensions.Logging;

namespace Gbim.Notification.Api.Senders
{
    public class EmailSender : ISender {
        private readonly MailConfig _config;
        private readonly MessageFactory _factory;
        private readonly ILogger<EmailSender> _logger;
        private readonly Regex _emailPattern = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");

        public EmailSender(MailConfig options, MessageFactory factory, ILogger<EmailSender> logger) {
            this._config = options;
            this._factory = factory;
            this._logger = logger;
        }

        public async Task<IExecutionResult> SendAsync(NotificationDto notification) {
            if (string.IsNullOrEmpty(notification.Receiver) || !_emailPattern.IsMatch(notification.Receiver)) {
                this._logger.LogWarning($"Адрес '{notification.Receiver}' не является корректным email");
                return ExecutionResult.Failure($"Адрес '{notification.Receiver}' не является корректным email");
            }

            try {
                var title = Regex.Replace(notification.Title, @"\t|\n|\r", string.Empty, RegexOptions.Compiled);
                var messageText = this._factory.GetMessage(notification);
                var message = new MailMessage(_config.Login, notification.Receiver, title, messageText);
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;

                if (notification.Attachments != null && notification.Attachments.Any()) {
                    foreach (var attachment in notification.Attachments) {
                        var stream = new MemoryStream(attachment.Content);
                        message.Attachments.Add(new Attachment(stream, attachment.Name, attachment.MimeType));
                    }
                }

                var client = new SmtpClient(_config.Host, _config.Port);
                client.Credentials = new NetworkCredential(_config.Login, _config.Password);
                client.Timeout = _config.Timeout * 1000;
                client.EnableSsl = _config.Ssl;
                Log.Logger.Information($"Начата отправка на {notification.Receiver}");
                await client.SendMailAsync(message);
                Log.Logger.Information($"Конец отправки на {notification.Receiver}");
                return ExecutionResult.Success();
            }
            catch (Exception ex) {
                Log.Logger.Error(ex, $"Ошибка отправки на {notification.Receiver}");
                return ExecutionResult.Failure(ex.Message);
            }
        }
        
        public async Task<IExecutionResult> SendAsync(LocalizedNotificationDto notification) {
            if (string.IsNullOrEmpty(notification.Receiver) || !_emailPattern.IsMatch(notification.Receiver)) {
                this._logger.LogWarning($"Адрес '{notification.Receiver}' не является корректным email");
                return ExecutionResult.Failure($"Адрес '{notification.Receiver}' не является корректным email");
            }

            try {
                var titleKk = Regex.Replace(notification.Title.Kk, @"\t|\n|\r", string.Empty, RegexOptions.Compiled);
                var titleRu = Regex.Replace(notification.Title.Ru, @"\t|\n|\r", string.Empty, RegexOptions.Compiled);
                var titleEn = Regex.Replace(notification.Title.En, @"\t|\n|\r", string.Empty, RegexOptions.Compiled);
                var messageText = this._factory.GetLocalizedMessage(notification);
                var message = new MailMessage(_config.Login, notification.Receiver, $"{titleKk}/{titleRu}/{titleEn}", messageText);
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;

                if (notification.Attachments != null && notification.Attachments.Any()) {
                    foreach (var attachment in notification.Attachments) {
                        var stream = new MemoryStream(attachment.Content);
                        message.Attachments.Add(new Attachment(stream, attachment.Name, attachment.MimeType));
                    }
                }

                var client = new SmtpClient(_config.Host, _config.Port);
                client.Credentials = new NetworkCredential(_config.Login, _config.Password);
                client.Timeout = _config.Timeout * 1000;
                client.EnableSsl = _config.Ssl;
                Log.Logger.Information($"Начата отправка на {notification.Receiver}");
                await client.SendMailAsync(message);
                Log.Logger.Information($"Конец отправки на {notification.Receiver}");
                return ExecutionResult.Success();
            }
            catch (Exception ex) {
                Log.Logger.Error(ex, $"Ошибка отправки на {notification.Receiver}");
                return ExecutionResult.Failure(ex.Message);
            }
        }
    }
}
