using System.Threading.Tasks;
using Gbim.Shared.DataContracts;
using Gbim.Notification.Api.Senders;
using Gbim.Notification.Client.DTO;
using Microsoft.AspNetCore.Mvc;
using NCANodeApi.Client.Services;
using NCANodeApi.Client.DataContracts.Requests;
using CSharpFunctionalExtensions;
using NCANodeApi.Client.DataContracts.Responses;

namespace Gbim.Notification.Api.Controllers {
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase {
        private readonly EmailSender _sender;
        private readonly NcaNodeService _ncaNodeService;

        public NotificationController(EmailSender sender, NcaNodeService ncaNodeService) {
            this._sender = sender;
            this._ncaNodeService = ncaNodeService;
            
        }

        [HttpPost]
        [Route("send")]
        public async Task<IExecutionResult> Send(NotificationDto message) => await this._sender.SendAsync(message);
        
        [HttpPost]
        [Route("sendLocalized")]
        public async Task<IExecutionResult> Send(LocalizedNotificationDto message) => await this._sender.SendAsync(message);

        [HttpPost]
        [Route("verify")]
        public async Task<IActionResult> Verify(VerifyXmlNcaRequest ncaRequest) => Ok(await this._ncaNodeService.VerifyXml(ncaRequest.Params.Xml, ncaRequest.Params.VerifyOcsp));
    }
}
