using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class RoleConfig : BaseEntityConfig<RoleEntity>
{
    protected override void Config(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Roles", schema: "portal");
        builder.OwnsOne(x => x.Name);
        builder.HasMany(x => x.Permissions).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
    }
}

public class RolePermissionConfig : IEntityTypeConfiguration<RolePermissionEntity>
{
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.ToTable("Roles_Permmissions");
        builder.HasKey(x => new { x.RoleId, x.PermissionId });
        builder.HasOne(x => x.Permission).WithMany().HasForeignKey(x => x.PermissionId);
        builder.HasOne(x => x.Role).WithMany(x => x.Permissions).HasForeignKey(x => x.RoleId);
    }
}