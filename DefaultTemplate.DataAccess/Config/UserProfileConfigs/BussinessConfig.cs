using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class BussinessConfig: BaseEntityConfig<BussinessEntity>
{
    protected override void Config(EntityTypeBuilder<BussinessEntity> builder)
    {
        builder.ToTable("Businesses");
        builder.HasOne(x => x.User).WithOne().HasForeignKey<BussinessEntity>(x => x.UserId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
