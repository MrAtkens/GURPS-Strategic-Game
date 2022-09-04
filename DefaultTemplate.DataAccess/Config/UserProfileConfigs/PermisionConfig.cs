
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.UserProfile;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs
{
    public class PermissionConfig : EnumEntityConfig<PermissionEntity>, IEntityTypeConfiguration<PermissionEntity>
    {
        protected override void Config(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("Permisions");
            builder.OwnsOne(x => x.Name);
            builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasMany(x => x.Roles).WithMany(x => x.Permissions);

        }
    }
}
