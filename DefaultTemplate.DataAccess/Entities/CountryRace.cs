
using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities;
public class CountryRaceEntity : BaseEntity
{
    public Guid CountryId { get; set; }
    public CountryEntity Country { get; set; }
    public Guid? RaceId { get; set; }
    public RaceEntity? Race { get; set; }
    public bool IsTitul { get; set; }
}
