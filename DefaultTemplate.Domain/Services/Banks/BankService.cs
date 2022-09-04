using FluentValidation;
using DefaultTemplate.Domain.Models.Banks;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Banks;

public class BankService : BaseReferenceService<Bank, BanksQuery>, IBankService
{
    protected override AbstractValidator<Bank>? Validator => new BankValidator();

    public BankService(IBankRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

}