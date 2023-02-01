using DefaultTemplate.Domain.Models.Permissions;

namespace DefaultTemplate.Domain.Models.Roles;

public class Role : NamedModel
{
    public string Code { get; set; }
    public ICollection<string> PermissionsIds { get; set; }
    public ICollection<EPermission> Permissions { get; set; }
}