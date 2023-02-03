using DefaultTemplate.Domain.Models.Waiters;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Waiters;

public interface IWaiterService : ICrudService<Waiter, WaiterQuery>
{
}