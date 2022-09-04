using AutoMapper;
using DefaultTemplate.DataAccess.Entities.UserProfile;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories;

public class PermissionRepository : EnumRepository<EPermission, PermissionEntity>
{
    public PermissionRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
    {
    }

    protected override void Update(EPermission model, PermissionEntity entity)
    {
        entity.Name = model.Name;
        entity.ParentId = model.ParentId;
    }
}
