using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class WaiterEntity : BaseEntity
{
    public UserEntity User { get; set; }
    public Guid UserId { get; set; }
    public double Rating { get; set; }
    public DateTime BirthDay { get; set; }
    public string Avatar { get; set; }
}