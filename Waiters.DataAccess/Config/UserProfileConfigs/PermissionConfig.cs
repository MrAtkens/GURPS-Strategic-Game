using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users.UserInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class PermissionConfig : EnumEntityConfig<PermissionEntity>
{
    protected override void Config(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder.ToTable("Permissions", schema: "portal");
        builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
    }
}