using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Models.ContactDetails;
using DefaultTemplate.Domain.Models.Roles;

namespace DefaultTemplate.Domain.Models.Users;

public class User: NamedModel
{
    public string LoginMail { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public IReadOnlyList<ContactDetail> ContactDetails { get; set; }
    public IReadOnlyList<AddressDetail> AddressDetails { get; set; }
}