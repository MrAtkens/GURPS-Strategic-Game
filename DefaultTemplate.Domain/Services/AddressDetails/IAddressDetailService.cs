using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.AddressDetails;
public interface IAddressDetailService : ICrudService<AddressDetail, AddressDetailQuery>
{
}

