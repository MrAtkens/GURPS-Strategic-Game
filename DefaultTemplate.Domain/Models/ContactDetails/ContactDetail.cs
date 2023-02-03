using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Enums;
namespace DefaultTemplate.Domain.Models.ContactDetails;

public class ContactDetail : BaseModel
{
    public string Value { get; set; }
    public ContactDetailType Type { get; set; }
}