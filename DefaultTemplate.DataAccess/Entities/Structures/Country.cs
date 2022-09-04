using DataAnnotationsExtensions;
using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities;
public class CountryEntity : NamedEntity
{
    public string Description { get; set; }
    public int MilitaryPower { get; set; }
    public double TechnologicalLevel { get; set; }
    public int TechnologicalGrowth { get; set; }
    public int Stability { get; set; }
    [Min(-100),Max(100)]
    public int Popularity { get; set; }
    public int Bureaucracy { get; set; }
    public long Economics { get; set; }
    public long Income { get; set; }
    public long Expenses { get; set; }
    public long StateTreasury { get; set; } 
    public long Population { get; set; }
    public long PopulationGrowth { get; set; }
    public ulong UnemployedPopulation { get; set; }
    public uint MalePopulationPercentage { get; set; }
    public uint FemalePopulationPercentage { get; set; }
    public virtual ICollection<CountryRaceEntity> CountryRaces { get; set; }
}