using DefaultTemplate.Common;
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Services.Common;
using DefaultTemplate.Domain.Services.Permissions;
using DefaultTemplate_Strategic.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTemplate_Strategic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : EnumController<IEnumService<EPermission>, EPermission>
{
    IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService) : base(permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpPost("all")]
    public Task<IReadOnlyList<EPermission>> GetList([FromBody] PermissionQuery query) => _permissionService.GetList(query);

    [AllowAnonymous]
    [HttpGet("hasPermission/{permissionId}")]
    public async Task<SingleValueModel<bool>> HasPermission(string permissionId)
        => new(await _permissionService.HasPermission(permissionId));
}
