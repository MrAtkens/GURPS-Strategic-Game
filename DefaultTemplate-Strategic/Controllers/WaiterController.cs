using DefaultTemplate.Api.Common;
using DefaultTemplate.Domain.Models.Waiters;
using DefaultTemplate.Domain.Services.Waiters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate_Strategic.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class WaiterController : DefaultController<IWaiterService, Waiter, WaiterQuery>
{
    public WaiterController(IWaiterService service) : base(service)
    {
    }
}