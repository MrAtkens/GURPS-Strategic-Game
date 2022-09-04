using DefaultTemplate.Domain.Models.Banks;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Banks;

public interface IBankService : ICrudService<Bank, BanksQuery>
{
    
}