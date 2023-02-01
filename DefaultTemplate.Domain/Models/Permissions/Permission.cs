using DefaultTemplate.Domain.Common;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Roles;

namespace DefaultTemplate.Domain.Models.Permissions;

public class EPermission : EnumModel
{
    public string? ParentId { get; set; }
    public EPermission? Parent { get; set; }
    public ICollection<Role> Roles { get; set; }

    
    public static readonly EPermission ViewGeneralReport = new()
    {
        Id = "viewGeneralReport",
        Name = "Просмот развёрнутого отчёта",
    };

    
    public static EPermission[] All =
    {
        ViewGeneralReport
    };
}