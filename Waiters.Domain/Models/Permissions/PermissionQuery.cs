using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Models.Permissions;

public class PermissionQuery : SearchQuery
{
    public string[]? PermissionsIds { get; set; }

}