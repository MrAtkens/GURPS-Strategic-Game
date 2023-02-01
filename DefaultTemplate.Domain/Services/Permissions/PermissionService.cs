using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Services.Common;
using DefaultTemplate.Domain.Services.System;
using Microsoft.Extensions.Caching.Memory;

namespace DefaultTemplate.Domain.Services.Permissions;

public class PermissionService : EnumService<EPermission>, IPermissionService
{
    private readonly IPermissionRepository _repository;
    private readonly IContextService _contextService;
    private readonly IMemoryCache _memoryCache;

    public PermissionService(
        IPermissionRepository repository,
        IContextService contextService,
        IServiceProvider serviceProvider,
        IMemoryCache memoryCache) : base(repository)
    {
        _repository = repository;
        _contextService = contextService;
        _memoryCache = memoryCache;
    }

    public Task<IReadOnlyList<EPermission>> GetList(PermissionQuery query) => _repository.GetList(query);

    public Task<bool> HasPermission(string permissionId)
    {
        var allPermissions = new List<EPermission>();

        if (_contextService.CurrentUser != null)
        {
            var key = _contextService.CurrentUser.Id;
            if (!_memoryCache.TryGetValue($"perms_{key}", out allPermissions))
            {
                allPermissions = _contextService.CurrentUser.Role?.Permissions.ToList();
            }

            _memoryCache.Set($"perms_{key}", allPermissions, DateTimeOffset.Now.AddMinutes(30));
        }

        return Task.FromResult(allPermissions?.Select(x => x.Id).Contains(permissionId) == true);
    }
}
