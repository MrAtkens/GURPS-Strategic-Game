using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.AddressDetails;
public interface IAddressDetailRepository : ICrudRepository<AddressDetail, AddressDetailQuery>
{
}
