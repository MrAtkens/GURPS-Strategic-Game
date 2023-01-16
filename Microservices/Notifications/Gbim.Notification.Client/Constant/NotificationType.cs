using System;

namespace Gbim.Notification.Client.Constant {
    public enum NotificationType {
        None = 0,
        Registration_ConfirmationCode = 1,
        Registration_RequestAccepted = 2,
        Registration_RequestDenied = 3,
        Registration_ProfileActivated = 4,
        Registration_ProfileDeactivated = 5,
    }
}