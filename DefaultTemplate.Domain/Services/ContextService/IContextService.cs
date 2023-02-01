
using DefaultTemplate.Domain.Models.Users;

namespace DefaultTemplate.Domain.Services.ContextService;

public interface IContextService
{ 
    public User? CurrentUser { get; set; }
    public long RegionId { get; set; }
    public bool CheckPermission(string permissionId);
    public long? ValidateToken(string token);
}