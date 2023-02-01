
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Permissions;

public interface IPermissionRepository : IEnumRepository<EPermission>
{
    public Task<IReadOnlyList<EPermission>> GetList(PermissionQuery query);
}