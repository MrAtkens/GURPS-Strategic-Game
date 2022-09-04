using FluentValidation;
using DefaultTemplate.Domain.Models.BankAccounts;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.BankAccounts;

public class BankAccountService : BaseService<BankAccount, BankAccountQuery>, IBankAccountService
{

    public BankAccountService(IBankAccountRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

}