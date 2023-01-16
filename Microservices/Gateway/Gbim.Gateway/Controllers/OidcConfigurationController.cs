using Gbim.Shared.Http.OIDC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Gbim.Gateway.Controllers
{
    [ApiController]
    [Route("api/oidc")]
    public class OidcConfigurationController : ControllerBase {
        private readonly IOptions<OpenIdConnectParams> _options;

        public OidcConfigurationController(IOptions<OpenIdConnectParams> options) {
            _options = options;
        }

        [HttpGet("_configuration")]
        public IActionResult GetClientRequestParameters() => Ok(_options.Value);
    }
}
