using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Config.Common;

public abstract class ReferenceEntityConfig<TEnum> : IEntityTypeConfiguration<TEnum> where TEnum : NamedEntity
{
    protected abstract void Config(EntityTypeBuilder<TEnum> builder);

    public void Configure(EntityTypeBuilder<TEnum> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreateById).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasOne(x => x.DeletedBy).WithMany().HasForeignKey(x => x.DeletedById).IsRequired(false).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.OwnsOne(x => x.Name);
        Config(builder);
    }
}


public abstract class EnumEntityConfig<TEnum> : IEntityTypeConfiguration<TEnum> where TEnum : EnumEntity
{
    protected abstract void Config(EntityTypeBuilder<TEnum> builder);

    public void Configure(EntityTypeBuilder<TEnum> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.Name);
        Config(builder);
    }
}

public abstract class BaseEntityConfig<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseEntity
{
    protected abstract void Config(EntityTypeBuilder<TDomain> builder);

    public void Configure(EntityTypeBuilder<TDomain> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreateById).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasOne(x => x.DeletedBy).WithMany().HasForeignKey(x => x.DeletedById).IsRequired(false).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        
        Config(builder);
    }
}