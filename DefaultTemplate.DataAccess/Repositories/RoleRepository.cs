using System.Linq.Expressions;
using AutoMapper;
using DefaultTemplate.DataAccess.Entities.UserProfile;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Roles;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.Roles;

namespace DefaultTemplate.DataAccess.Repositories;


public class RoleRepository : BaseRepository<Role, RoleEntity, RoleQuery>, IRoleRepository
{
    public RoleRepository(GbimContext context, IMapper mapper, IContextService contextService) : base(context, mapper, contextService)
    {
    }

    protected override void Update(RoleEntity entity, Role model)
    {
        entity.Name = model.Name;
        entity.isDefault = model.isDefault;
        entity.ActivityTypeEnumId = model.ActivityTypeEnumId;
        entity.Code = model.Code;
        if(model.PermisionsIds != null)
        {
            List<PermissionEntity> permissions = new List<PermissionEntity>();
            model.PermisionsIds.ForEach(item =>
            {
                var permission = this._context.Permisions.FirstOrDefault(x => x.Id == item);
                permissions.Add(permission);
            });
            entity.Permissions = permissions;
        }
    }

    protected override Expression<Func<Role, object>>[] IncludeAggregated() => new Expression<Func<Role, object>>[]
    {
            x => x.PermisionsIds,
            x => x.Permissions,
            x => x.WorkplacesIds,
            x => x.Workplaces,
            x => x.UsersIds,
            x => x.Users,
    };
}

