using DefaultTemplate.Domain.Models.Waiters;
using DefaultTemplate.Domain.Options;
using DefaultTemplate.Domain.Services.Common;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace DefaultTemplate.Domain.Services.Waiters;

public class WaiterService: BaseService<Waiter, WaiterQuery>, IWaiterService
{
    private readonly IOptions<JwtOptions> _options;
    protected override AbstractValidator<Waiter>? Validator => new WaiterValidator();

    public WaiterService(IWaiterRepository repository, IUnitOfWork unitOfWork, IOptions<JwtOptions> options) : base(repository, unitOfWork)
    {
        _options = options;
    }
}