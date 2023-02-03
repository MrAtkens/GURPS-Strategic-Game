using AutoMapper;
using AutoMapper.QueryableExtensions;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Entities.Users.UserInfo;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Services.Permissions;
using Microsoft.EntityFrameworkCore;

namespace DefaultTemplate.DataAccess.Repositories;

public class PermissionRepository: EnumRepository<EPermission, PermissionEntity>, IPermissionRepository
{
    public PermissionRepository(DefaultContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override void Update(EPermission model, PermissionEntity entity)
    {
        entity.Name = model.Name;
        entity.ParentId = model.ParentId;
    }

    public IQueryable<PermissionEntity> Search(IQueryable<PermissionEntity> dbQuery, PermissionQuery query)
    {
        if (query.PermissionsIds?.Any() == true)
            dbQuery = dbQuery.Where(x => query.PermissionsIds.Contains(x.Id));
        return dbQuery;
    }

    public IQueryable<PermissionEntity> GetDbQuery(PermissionQuery query)
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<IReadOnlyList<EPermission>> GetList(PermissionQuery query)
    {
        var dbQuery = GetDbQuery(query);
        return await Search(dbQuery, query).ProjectTo<EPermission>(_mapper.ConfigurationProvider, null, query.Includes).ToListAsync();
    }
}
