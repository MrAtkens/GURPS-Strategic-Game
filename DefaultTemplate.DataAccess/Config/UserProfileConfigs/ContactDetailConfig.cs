using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;
public class ContactDetailConfig : IEntityTypeConfiguration<ContactDetailEntity>
{
    public void Configure(EntityTypeBuilder<ContactDetailEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("ContactDetails");
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
