using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class RoleEntity : NamedEntity
{
    public string Code { get; set; }
    public virtual ICollection<RolePermissionEntity> Permissions { get; set; }
}