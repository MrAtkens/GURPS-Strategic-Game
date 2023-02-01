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
            RuleFor(entity => entity.Name).NotEmpty().MaximumLength(maximumNameLength);
        }
    }
}
