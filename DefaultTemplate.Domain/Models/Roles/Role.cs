using DefaultTemplate.Domain.Models.Permissions;

namespace DefaultTemplate.Domain.Models.Roles;

public class Role: NamedModel
{
    private List<Permission> Permissions { get; set; }
}