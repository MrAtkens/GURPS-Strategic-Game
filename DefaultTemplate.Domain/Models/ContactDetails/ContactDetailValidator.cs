using DefaultTemplate.Domain.Models.Common;
using FluentValidation;

namespace DefaultTemplate.Domain.Models.ContactDetails;

internal class ContactDetailValidator: BaseValidator<ContactDetail>
{
    public ContactDetailValidator() : base()
    {
        RuleFor(x => x.Value).NotEmpty().WithMessage("Контакт должен быть заполнен");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Тип контакта должен быть заполнен");
    }
  
}