using DefaultTemplate.Domain.Models.Common;
using FluentValidation;

namespace DefaultTemplate.Domain.Models.Bussineses;

public class BussinessValidator: BaseValidator<Business>
{
    public BussinessValidator() : base()
    {
        RuleFor(x => x.Bin).NotEmpty().WithMessage("Бин не должен быть пустым");
    }

}