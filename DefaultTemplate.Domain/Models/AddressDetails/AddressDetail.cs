using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.Domain.Models.AddressDetails;

public class AddressDetail: BaseModel
{
    public string Value { get; set; }
    public AddressDetailType Type { get; set; }
}