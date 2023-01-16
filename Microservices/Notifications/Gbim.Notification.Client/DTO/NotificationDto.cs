﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gbim.Notification.Client.Constant;

namespace Gbim.Notification.Client.DTO
{
    public class NotificationDto : IValidatableObject {
        /// <summary>
        /// Получатель
        /// </summary>
        public string Receiver { get; set; }
        /// <summary>
        /// Заголовок сообщения
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Текст простого сообщения
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Значения плейсхолдеров (если используется шаблон)
        /// </summary>
        public Dictionary<string, string> Content { get; set; }
        /// <summary>
        /// Тип уведомления
        /// </summary>
        public NotificationType Type { get; set; }
        /// <summary>
        /// Вложения
        /// </summary>
        public List<AttachmentDto> Attachments { get; set; } = new List<AttachmentDto>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (Type == NotificationType.Registration_ConfirmationCode && !Content.ContainsKey(FieldNames.Code)) {
                return new[] { new ValidationResult("Не заполнено значение поля", new[] { nameof(this.Content) }) };
            }
            return new[] { ValidationResult.Success };
        }
    }
}