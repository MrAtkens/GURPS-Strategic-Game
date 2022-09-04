using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.UserProfile;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs
{
    public class RoleConfig : BaseEntityConfig<RoleEntity>, IEntityTypeConfiguration<RoleEntity>
    {
        protected override void Config(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("RoleEntities");
            builder.OwnsOne(x => x.Name);
            builder.HasOne(x => x.ActivityTypeEnum).WithMany().HasForeignKey(x => x.ActivityTypeEnumId)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasMany(x => x.Permissions).WithMany(x => x.Roles);
            builder.HasMany(x => x.Users).WithMany(x => x.Roles);
            builder.HasMany(x => x.Workplaces).WithMany(x => x.Roles);

        }
    }
}
