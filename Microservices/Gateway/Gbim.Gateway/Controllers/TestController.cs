using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gbim.Gateway.Services;
using Gbim.Shared.DataContracts;
using Microsoft.AspNetCore.Authorization;

namespace Gbim.Gateway.Controllers {
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase {
        private IProfileService _accountService;

        public TestController(IProfileService accountService) {
            this._accountService = accountService;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> Get() {
            return await Task.FromResult(new JsonResult(ExecutionResult.Success()));
        }

        [HttpGet]
        [Route("account/byIin/{iin}")]
        public async Task<IActionResult> GetAccountByIin(string iin) {
            return new JsonResult(await _accountService.GetUserAccountByIinAsync(iin));
        }
        
        [HttpGet]
        [Route("account/byLogin/{login}")]
        public async Task<IActionResult> GetAccountByLogin(string login) {
            return new JsonResult(await _accountService.GetUserAccountByLoginAsync(login));
        }
    }
}