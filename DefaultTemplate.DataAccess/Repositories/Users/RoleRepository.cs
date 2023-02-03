using System.Linq.Expressions;
using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Roles;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.Roles;

namespace DefaultTemplate.DataAccess.Repositories.Users;

public class RoleRepository : BaseRepository<Role, RoleEntity, RoleQuery>, IRoleRepository
{
    public RoleRepository(DefaultContext context, IMapper mapper, IContextService contextService) : base(context,
        mapper, contextService)
    {
    }

    protected override void Update(RoleEntity entity, Role model)
    {
        entity.Name = model.Name!;
        entity.Code = model.Code;
        var existsPermissions = _context.RolesPermissions.Where(x => x.RoleId == model.Id).ToArray();
        var forAdd = model.PermissionsIds.Where(id => !existsPermissions.Any(x => x.PermissionId == id)).Select(id => new RolePermissionEntity
        {
            PermissionId = id,
            RoleId = model.Id
        }).DistinctBy(x => x.PermissionId).ToArray();

        _context.RolesPermissions.AddRange(forAdd);

        var forRemove = existsPermissions.Where(x => !model.PermissionsIds.Contains(x.PermissionId)).ToArray();
        _context.RolesPermissions.RemoveRange(forRemove);
    }

    protected override IQueryable<RoleEntity> Search(IQueryable<RoleEntity> dbQuery, RoleQuery query)
    {
        if (query.Ids?.Any() == true)
            dbQuery = dbQuery.Where(x => query.Ids.Contains(x.Id));
        if (query.ExcludeIds?.Any() == true)
            dbQuery = dbQuery.Where(x => !query.ExcludeIds.Contains(x.Id));
        
        return dbQuery;
    }

    protected override Expression<Func<Role, object>>[] IncludeAggregated() => new Expression<Func<Role, object>>[]
    {
        x => x.Permissions,
    };
}