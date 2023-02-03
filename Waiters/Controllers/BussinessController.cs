using DefaultTemplate.Api.Common;
using DefaultTemplate.Domain.Models.Bussineses;
using DefaultTemplate.Domain.Services.Bussineses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate_Strategic.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class BussinessController : DefaultController<IBussinessService, Business, BussinessQuery>
{
    public BussinessController(IBussinessService service) : base(service)
    {
    }
}