using FluentValidation;
using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.AddressDetails;
public class AddressDetailService : BaseService<AddressDetail, AddressDetailQuery>, IAddressDetailService
{
    protected override AbstractValidator<AddressDetail>? Validator => new AddressDetailValidator();

    public AddressDetailService(IAddressDetailRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

}