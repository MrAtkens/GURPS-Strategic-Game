using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class WaiterConfig: BaseEntityConfig<WaiterEntity>
{
    protected override void Config(EntityTypeBuilder<WaiterEntity> builder)
    {
        builder.ToTable("Waiters");
        builder.HasOne(x => x.User).WithOne().HasForeignKey<WaiterEntity>(x => x.UserId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
