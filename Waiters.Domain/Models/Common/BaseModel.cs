using DefaultTemplate.Domain.Common;

namespace DefaultTemplate.Domain.Models.Common;

public class BaseModel : IAuditable
{
    public Guid Id { get; set; }
    public Guid CreateById { get; set; }
    public NatPersonLookup? CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public Guid ModifiedById { get; set; }
    public NatPersonLookup? ModifiedBy { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
}

public class NatPersonLookup
{
    public string FullName { get; set; }
    public DateTimeOffset BirthDay { get; set; }
}

public class NamedModel : BaseModel
{
    public Localizable? Name { get; set; }
}

public interface IDeletable
{
    public bool IsDeleted { get; set; }
    public Guid? DeletedById { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}

public interface IAuditable
{
    public Guid CreateById { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public Guid ModifiedById { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
}