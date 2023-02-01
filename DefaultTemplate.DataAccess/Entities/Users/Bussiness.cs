using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class BussinessEntity : BaseEntity
{
    public string Bin { get; set; }
    public UserEntity User { get; set; }
    public Guid UserId { get; set; }
    public Guid ParentId { get; set; }
    public DateTime RegistrationDate { get; set; }
}