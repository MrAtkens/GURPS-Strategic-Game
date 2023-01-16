using Gbim.Notification.Client.Constant;
using Gbim.Notification.Client.DTO;

namespace Gbim.Notification.Api.Message {
    public class MessageFactory {
        /// <summary> Сформировать текст сообщения для отправки </summary>
        public string GetMessage(NotificationDto notification) {
            var text = string.Empty;
            switch (notification.Type) {
                case NotificationType.Registration_ConfirmationCode:
                    text = string.Format(EmailTemplate.ConfirmationCode, notification.Content[FieldNames.Code]);
                    break;
                case NotificationType.Registration_RequestAccepted:
                    text = string.Format(EmailTemplate.RegRequestAccept);
                    break;
                case NotificationType.Registration_RequestDenied:
                    text = string.Format(EmailTemplate.RegRequestDeny, notification.Content[FieldNames.Reason]);
                    break;
                case NotificationType.Registration_ProfileActivated:
                    text = string.Format(EmailTemplate.ProfileActivated);
                    break;
                case NotificationType.Registration_ProfileDeactivated:
                    text = string.Format(EmailTemplate.ProfileDeactivated, notification.Content[FieldNames.Reason]);
                    break;
                default:
                    text = string.Format(EmailTemplate.SimpleMessage, notification.Title, notification.Message);
                    break;
            }
            return text;
        }
        
        /// <summary> Сформировать локализованный текст сообщения для отправки </summary>
        public string GetLocalizedMessage(LocalizedNotificationDto notification) {
            var text = string.Empty;
            switch (notification.Type) {
                case NotificationType.Registration_ConfirmationCode:
                    text = string.Format(EmailTemplate.ConfirmationCode, notification.Content[FieldNames.Code]);
                    break;
                case NotificationType.Registration_RequestAccepted:
                    text = string.Format(EmailTemplate.RegRequestAccept);
                    break;
                case NotificationType.Registration_RequestDenied:
                    text = string.Format(EmailTemplate.RegRequestDeny, notification.Content[FieldNames.Reason]);
                    break;
                case NotificationType.Registration_ProfileActivated:
                    text = string.Format(EmailTemplate.ProfileActivated);
                    break;
                case NotificationType.Registration_ProfileDeactivated:
                    text = string.Format(EmailTemplate.ProfileDeactivated, notification.Content[FieldNames.Reason]);
                    break;
                default:
                    text = string.Format(EmailTemplate.LocalizedSimpleMessage, notification.Title, 
                        notification.Message.Kk, notification.Message.Ru, notification.Message.En);
                    break;
            }
            return text;
        }
    }
}
