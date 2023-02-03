using DefaultTemplate.Domain.Models.Bussineses;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.Bussineses;

public interface IBussinessRepository : ICrudRepository<Business, BussinessQuery>
{
    
}