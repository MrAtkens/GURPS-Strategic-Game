using DefaultTemplate.Domain.Models.Common;
using FluentValidation;

namespace DefaultTemplate.Domain.Models.Users;

public class UserValidator: BaseValidator<User>
{
    public UserValidator() : base()
    {
        RuleFor(x => x.LoginMail).NotEmpty().WithMessage("Почта обязательна должна быть заполнена");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Организация обязательна должна быть заполнена");
        RuleFor(x => x.Password).NotEmpty().WithMessage("ФИО обязательна должна быть заполнена");
    }

}