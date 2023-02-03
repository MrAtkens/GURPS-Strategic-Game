using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class UserConfig: BaseEntityConfig<UserEntity>
{
    protected override void Config(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasIndex(x => x.LoginMail).IsUnique();
        builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId).IsRequired(false).Metadata.DeleteBehavior =
                DeleteBehavior.Restrict;
    }
}
