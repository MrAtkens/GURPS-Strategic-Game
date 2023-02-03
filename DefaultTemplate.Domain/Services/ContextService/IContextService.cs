
using DefaultTemplate.Domain.Models.Bussineses;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Models.Waiters;

namespace DefaultTemplate.Domain.Services.ContextService;

public interface IContextService
{ 
    public User CurrentUser { get; set; }
    public Waiter? CurrentWaiter { get; set; }
    public Business? CurrentBussiness { get; set; }
    public bool CheckPermission(string permissionId);
    public Guid? ValidateToken(string token);
}