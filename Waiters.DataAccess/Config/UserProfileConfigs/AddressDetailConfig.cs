using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users.UserInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class AddressDetailConfig: BaseEntityConfig<AddressDetailEntity>
{
    protected override void Config(EntityTypeBuilder<AddressDetailEntity> builder)
    {
        builder.ToTable("AddressDetails");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
