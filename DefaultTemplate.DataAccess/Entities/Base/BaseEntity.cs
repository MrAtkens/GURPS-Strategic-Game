using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.Domain.Models;

namespace DefaultTemplate.DataAccess.Entities.Base;

public class BaseEntity : IEntity<Guid>, IAuditable, IDeletable
{
    public Guid Id { get; set; }
    public UserEntity CreatedBy { get; set; }
    public Guid CreateById { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    
    public Guid ModifiedById { get; set; }
    public UserEntity ModifiedBy { get; set; }
    
    public DateTimeOffset ModifiedDate { get; set; }
    
    public bool IsDeleted { get; set; }
    public Guid? DeletedById { get; set; }
    
    public UserEntity DeletedBy { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}