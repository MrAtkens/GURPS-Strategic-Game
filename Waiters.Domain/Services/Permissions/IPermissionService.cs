using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Permissions;

public interface IPermissionService : IEnumService<EPermission>
{
    public Task<IReadOnlyList<EPermission>> GetList(PermissionQuery query);
    Task<bool> HasPermission(string permissionId);
}
