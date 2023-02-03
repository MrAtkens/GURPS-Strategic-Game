using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Config.Common;

public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    protected abstract void Config(EntityTypeBuilder<TEntity> builder);

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreateById).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasOne(x => x.DeletedBy).WithMany().HasForeignKey(x => x.DeletedById).IsRequired(false).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        Config(builder);
    }
}

public abstract class NamedEntityConfig<TEnum> : IEntityTypeConfiguration<TEnum> where TEnum : NamedEntity
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
