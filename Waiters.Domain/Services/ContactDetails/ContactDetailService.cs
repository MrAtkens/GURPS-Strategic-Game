using DefaultTemplate.Domain.Models.ContactDetails;
using DefaultTemplate.Domain.Services.Common;
using FluentValidation;

namespace DefaultTemplate.Domain.Services.ContactDetails;

public class ContactDetailService : BaseService<ContactDetail, ContactDetailQuery>, IContactDetailService
{
    protected override AbstractValidator<ContactDetail>? Validator => new ContactDetailValidator();

    public ContactDetailService(IContactDetailRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

}