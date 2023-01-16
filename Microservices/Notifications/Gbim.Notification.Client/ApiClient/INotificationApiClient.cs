using System.Threading.Tasks;
using Gbim.Shared.DataContracts;

namespace Gbim.Notification.Client.ApiClient {
    public interface INotificationApiClient {
        /// <summary>
        /// Отправить код подтверждения регистрации
        /// </summary>
        /// <param name="recipient">Email получателя</param>
        /// <param name="code">Код подтверждения</param>
        Task<IExecutionResult> SendConfirmationCode(string recipient, string code);

        /// <summary>
        /// Отправить уведомление об успешной регистрации
        /// </summary>
        /// <param name="recipient">Email получателя</param>
        Task<IExecutionResult> SendAcceptNotification(string recipient);

        /// <summary>
        /// Отправить уведомление об отказе в регистрации
        /// </summary>
        /// <param name="recipient">Email получателя</param>
        /// <param name="reason">Причина отказа</param>
        Task<IExecutionResult> SendDenyNotification(string recipient, string reason);

        /// <summary>
        /// Отправить уведомление об активации профиля
        /// </summary>
        /// <param name="recipient">Email получателя</param>
        Task<IExecutionResult> SendProfileActivatedNotification(string recipient);

        /// <summary>
        /// Отправить уведомление о деактивации профиля
        /// </summary>
        /// <param name="recipient">Email получателя</param>
        /// <param name="reason">Причина отказа</param>
        Task<IExecutionResult> SendProfileDeactivatedNotification(string recipient, string reason);
    }
}