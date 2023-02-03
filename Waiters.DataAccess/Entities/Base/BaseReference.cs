
namespace DefaultTemplate.DataAccess.Entities.Base;
public class BaseReference : NamedEntity
{
    public Guid? RefHistory { get; set; }
    public DateTimeOffset? DateStart { get; set; }
    public DateTimeOffset? DateEnd { get; set; }
}
