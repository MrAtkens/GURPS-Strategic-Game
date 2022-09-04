using DefaultTemplate.DataAccess.Entities.Base;
namespace DefaultTemplate.DataAccess.Entities;

public class RaceEntity : NamedEntity
{
    public string Description { get; set; }
    public int Intelligence { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int FatiquePoint { get; set; }
    public virtual ICollection<CountryRaceEntity>? CountryRaces { get; set; }
}
