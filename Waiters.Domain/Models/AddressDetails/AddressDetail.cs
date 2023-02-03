using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.Domain.Models.AddressDetails;

public class AddressDetail: BaseModel
{
    public string Value { get; set; }
    public AddressDetailType Type { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
}