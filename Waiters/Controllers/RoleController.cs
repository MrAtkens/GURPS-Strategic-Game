using DefaultTemplate.Api.Common;
using DefaultTemplate.Domain.Models.Roles;
using DefaultTemplate.Domain.Services.Roles;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate_Strategic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : DefaultController<IRoleService, Role, RoleQuery>
{
    public RoleController(IRoleService service) : base(service)
    {
    }
}