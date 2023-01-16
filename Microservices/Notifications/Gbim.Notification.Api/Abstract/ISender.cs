using System.Threading.Tasks;
using Gbim.Shared.DataContracts;
using Gbim.Notification.Client.DTO;

namespace Gbim.Notification.Api.Abstract {
    public interface ISender {
        Task<IExecutionResult> SendAsync(NotificationDto notification);
        Task<IExecutionResult> SendAsync(LocalizedNotificationDto notification);
    }
}