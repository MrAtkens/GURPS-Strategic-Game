using FluentValidation;
using DefaultTemplate.Domain.Models;

namespace DefaultTemplate.Domain.Models.Common
{
    internal class BaseValidator<T> : AbstractValidator<T> where T : BaseModel
    {
        public BaseValidator()
        {

        }
    }
    internal class NamedValidator<T> : BaseValidator<T> where T : NamedModel
    {
        public NamedValidator(int maximumNameLength = 300)
        {
            RuleFor(entity => entity.Name.Ru).NotEmpty().MaximumLength(maximumNameLength);
            RuleFor(entity => entity.Name.En).NotEmpty().MaximumLength(maximumNameLength);
            RuleFor(entity => entity.Name.Kk).NotEmpty().MaximumLength(maximumNameLength);
        }
    }
}
