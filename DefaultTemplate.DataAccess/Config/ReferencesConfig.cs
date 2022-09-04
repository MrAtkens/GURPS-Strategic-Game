using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities;

namespace DefaultTemplate.DataAccess.Config;

public class CountryEntityConfig : BaseEntityConfig<CountryEntity>
{
    protected override void Config(EntityTypeBuilder<CountryEntity> builder)
    {
        builder.ToTable("Contries");
        
    }
}

public class RaceEntityConfig : BaseEntityConfig<RaceEntity>
{
    protected override void Config(EntityTypeBuilder<RaceEntity> builder)
    {
        builder.ToTable("Races");
    }
}

public class CountryRaceConfig : BaseEntityConfig<CountryRaceEntity>
{
    protected override void Config(EntityTypeBuilder<CountryRaceEntity> builder)
    {
        builder.ToTable("CountryRaces");
        builder.HasOne(x => x.Country).WithMany(c => c.CountryRaces).HasForeignKey(x => x.CountryId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasOne(x => x.Race).WithMany(r => r.CountryRaces).HasForeignKey(x => x.RaceId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        builder.HasKey(x => new { x.RaceId, x.CountryId });
    }
}
