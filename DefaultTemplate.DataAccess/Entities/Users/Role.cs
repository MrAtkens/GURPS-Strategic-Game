using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class RoleEntity : NamedEntity
{
    private List<PermissionEntity> Permissions { get; set; }
}