using FluentValidation;

namespace DefaultTemplate.Domain.Models.Common
{
    public class BaseValidator<T> : AbstractValidator<T> where T : BaseModel
    {
        public BaseValidator()
        {

        }
    }

    public class NamedValidator<T> : BaseValidator<T> where T : NamedModel
    {
        public NamedValidator(int maximumNameLength = 300)
        {
            RuleFor(entity => entity.Name.Ru).NotEmpty().MaximumLength(maximumNameLength);
            RuleFor(entity => entity.Name.Kk).NotEmpty().MaximumLength(maximumNameLength);
            RuleFor(entity => entity.Name.En).NotEmpty().MaximumLength(maximumNameLength);

        }
    }
}
