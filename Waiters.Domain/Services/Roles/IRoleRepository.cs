using DefaultTemplate.Domain.Models.Roles;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Roles;

public interface IRoleRepository : ICrudRepository<Role, RoleQuery>
{
    
}