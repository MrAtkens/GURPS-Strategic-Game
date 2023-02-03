using DefaultTemplate.Common;
using DefaultTemplate.Domain.DTOs;
using DefaultTemplate.Domain.Models.Waiters;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Waiters;

public interface IWaiterRepository : ICrudRepository<Waiter, WaiterQuery>
{
}