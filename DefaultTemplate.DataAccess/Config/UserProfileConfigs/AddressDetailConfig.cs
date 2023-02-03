﻿using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.DataAccess.Config.UserProfileConfigs;

public class AddressDetailConfig: BaseEntityConfig<AddressDetailEntity>
{
    protected override void Config(EntityTypeBuilder<AddressDetailEntity> builder)
    {
        builder.ToTable("Address");
        builder.HasKey(x => x.Id);
        builder.ToTable("AddressDetails");
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
