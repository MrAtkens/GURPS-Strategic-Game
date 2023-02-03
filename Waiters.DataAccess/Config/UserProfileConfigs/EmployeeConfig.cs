using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class EmployeeConfig: BaseEntityConfig<EmployeeEntity>
{
    protected override void Config(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("Employees");
        builder.HasOne(x => x.User).WithOne().HasForeignKey<EmployeeEntity>(x => x.UserId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
