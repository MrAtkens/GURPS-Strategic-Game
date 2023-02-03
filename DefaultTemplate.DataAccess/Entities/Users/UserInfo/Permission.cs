using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class PermissionEntity : EnumEntity
{
    public string? ParentId { get; set; }
    public PermissionEntity? Parent { get; set; }
    public virtual ICollection<RolePermissionEntity> Roles { get; set; }
}