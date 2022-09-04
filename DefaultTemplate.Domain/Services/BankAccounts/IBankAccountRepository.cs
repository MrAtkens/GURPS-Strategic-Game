using DefaultTemplate.Domain.Models.BankAccounts;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.BankAccounts;

public interface IBankAccountRepository : ICrudRepository<BankAccount, BankAccountQuery>
{
    
}