using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Gbim.Shared.DataContracts;
using Gbim.Notification.Client.Constant;
using Gbim.Notification.Client.DTO;
using Gbim.Shared.Constant;
using Gbim.Shared.Http.Clients;

namespace Gbim.Notification.Client.ApiClient {
    public class NotificationApiClient : BaseHttpClient, INotificationApiClient {
        protected override string ClientName { get; } = ConfigSection.NOTIFICATION_API;
        public NotificationApiClient(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public async Task<IExecutionResult> SendConfirmationCode(string recipient, string code) {
            var model = new NotificationDto {
                Receiver = recipient,
                Title = "«MAMB» eseptik jazbasy úshin rastaý kody / Код подтверждения для учетной записи «ГБИМ» / The verification code for the account of «SBIM» system",
                Content = new Dictionary<string, string>() {
                    {FieldNames.Code, code}
                },
                Type = NotificationType.Registration_ConfirmationCode,
                Attachments = new List<AttachmentDto>()
            };

            return await Send<NotificationDto, ExecutionResult>("api/notification/send", HttpMethod.Post, model);
        }

        public async Task<IExecutionResult> SendAcceptNotification(string recipient) {
            var model = new NotificationDto {
                Receiver = recipient,
                Title = "Tirkeý nátıjesi / Результат регистрации / The result of the registration",
                Content = new Dictionary<string, string>(),
                Type = NotificationType.Registration_RequestAccepted,
                Attachments = new List<AttachmentDto>()
            };

            return await Send<NotificationDto, ExecutionResult>("api/notification/send", HttpMethod.Post, model);
        }

        public async Task<IExecutionResult> SendDenyNotification(string recipient, string reason) {
            var model = new NotificationDto {
                Receiver = recipient,
                Title = "Tirkeý nátıjesi / Результат регистрации / The result of the registration",
                Content = new Dictionary<string, string>() {
                    {FieldNames.Reason, reason}
                },
                Type = NotificationType.Registration_RequestDenied,
                Attachments = new List<AttachmentDto>()
            };

            return await Send<NotificationDto, ExecutionResult>("api/notification/send", HttpMethod.Post, model);
        }

        public async Task<IExecutionResult> SendProfileActivatedNotification(string recipient) {
            var model = new NotificationDto {
                Receiver = recipient,
                Title = "Eseptik jazbanyń kúıin ózgertý / Изменение статуса учетной записи / Changing the account status",
                Content = new Dictionary<string, string>(),
                Type = NotificationType.Registration_ProfileActivated,
                Attachments = new List<AttachmentDto>()
            };

            return await Send<NotificationDto, ExecutionResult>("api/notification/send", HttpMethod.Post, model);
        }

        public async Task<IExecutionResult> SendProfileDeactivatedNotification(string recipient, string reason) {
            var model = new NotificationDto {
                Receiver = recipient,
                Title = "Eseptik jazbanyń kúıin ózgertý / Изменение статуса учетной записи / Changing the account status",
                Content = new Dictionary<string, string>() {
                    {FieldNames.Reason, reason}
                },
                Type = NotificationType.Registration_ProfileDeactivated,
                Attachments = new List<AttachmentDto>()
            };

            return await Send<NotificationDto, ExecutionResult>("api/notification/send", HttpMethod.Post, model);
        }
    }
}
