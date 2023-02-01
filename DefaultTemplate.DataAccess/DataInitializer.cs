using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Repositories;
using DefaultTemplate.Domain;
using Microsoft.Extensions.DependencyInjection;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Models.Roles;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.DataAccess;

public class DataInitializer
{
    private readonly IServiceProvider _services;

    public DataInitializer(IServiceProvider services)
    {
        _services = services;
    }

    public async Task Init()
    {
        var unitOfWork = _services.GetRequiredService<IUnitOfWork>();
        await SaveEnum<PermissionRepository, EPermission>(Permissions.List);
        await Save<RoleRepository, Role, RoleQuery>(Roles.List);
        await unitOfWork.SaveChangesAsync();
    }

    async Task Save<TRepository, TDomain, TQuery>(IReadOnlyList<TDomain> models)
        where TRepository : ICrudRepository<TDomain, TQuery>
        where TDomain : BaseModel
        where TQuery : SearchQuery
    {
        var rep = _services.GetRequiredService<TRepository>();
        foreach (var model in models)
        {
            await rep.SaveAsync(model, true);
        }
        
    }
    
    async Task SaveEnum<TRepository, TEnum>(IReadOnlyList<TEnum> models)
        where TRepository : IEnumRepository<TEnum>
        where TEnum : EnumModel
    {
        var rep = _services.GetRequiredService<TRepository>();
        foreach (var model in models)
        {
            await rep.Save(model);
        }
    }
}