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
        
    }
}
