using DefaultTemplate.Domain.Models;

namespace DefaultTemplate.DataAccess.Entities.Base;

public class BaseEntity : IEntity<Guid>, IAuditable, IDeletable
{
    public Guid Id { get; set; }
    public NatPersonEntity CreatedBy { get; set; }
    public Guid CreateById { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    
    public Guid ModifiedById { get; set; }
    public NatPersonEntity ModifiedBy { get; set; }
    
    public DateTimeOffset ModifiedDate { get; set; }
    
    public bool IsDeleted { get; set; }
    public Guid? DeletedById { get; set; }
    
    public NatPersonEntity DeletedBy { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}