using DefaultTemplate.DataAccess.Entities.Base;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class UserEntity : NamedEntity
{
    public string LoginMail { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
    public RoleEntity? Role { get; set; }
    public IReadOnlyList<ContactDetailEntity>? ContactDetails { get; set; }
    public IReadOnlyList<AddressDetailEntity>? AddressDetails { get; set; }
}