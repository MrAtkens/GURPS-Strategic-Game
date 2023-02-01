using DefaultTemplate.DataAccess.Entities.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class ContactDetailEntity : BaseEntity
{
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    public string Value { get; set; }
    public ContactDetailType Type { get; set; }
}