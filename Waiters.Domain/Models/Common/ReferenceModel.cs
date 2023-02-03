

namespace DefaultTemplate.Domain.Models.Common;
public class ReferenceModel : NamedModel
{
    public Guid? RefHistory { get; set; }
    public DateTimeOffset? DateStart { get; set; }
    public DateTimeOffset? DateEnd { get; set; }
}
