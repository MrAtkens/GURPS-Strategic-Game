using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class EmployeeEntity : BaseEntity
{
    public UserEntity User { get; set; }
    public Guid UserId { get; set; }
}