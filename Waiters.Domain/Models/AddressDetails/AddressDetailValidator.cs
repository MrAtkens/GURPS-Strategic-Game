using System.Data;
using DefaultTemplate.Domain.Models.Common;
using FluentValidation;

namespace DefaultTemplate.Domain.Models.AddressDetails;

internal class AddressDetailValidator : BaseValidator<AddressDetail>
{
    public AddressDetailValidator() : base()
    {
        RuleFor(x => x.Value).NotEmpty().WithMessage("Адрес должен быть заполнен");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Тип адреса должен быть заполнен");
    }
  
}