using System;
using System.Collections.Generic;
using System.Text;

namespace Gbim.Notification.Client.DTO {
    public class AttachmentDto {
        public string Name { get; set; }
        public string MimeType { get; set; }
        public byte[] Content { get; set; }
    }
}
