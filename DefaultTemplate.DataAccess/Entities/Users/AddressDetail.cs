using DefaultTemplate.DataAccess.Entities.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Entities.Users;

public class AddressDetailEntity : BaseEntity
{
    public string Value { get; set; }
    public AddressDetailType Type { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
}