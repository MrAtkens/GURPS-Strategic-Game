using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class AddressDetailConfig: BaseEntityConfig<AddressDetailEntity>
{
    protected override void Config(EntityTypeBuilder<AddressDetailEntity> builder)
    {
        builder.ToTable("Address");
    }
}
