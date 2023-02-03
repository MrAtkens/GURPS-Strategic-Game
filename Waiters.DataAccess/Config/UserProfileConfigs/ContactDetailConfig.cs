using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users.UserInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;
public class ContactDetailConfig : BaseEntityConfig<ContactDetailEntity>
{
    protected override void Config(EntityTypeBuilder<ContactDetailEntity> builder)
    {
        builder.ToTable("ContactDetails");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;    
    }
}
