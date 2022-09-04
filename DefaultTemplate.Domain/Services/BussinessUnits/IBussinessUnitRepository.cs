using DefaultTemplate.Domain.Models.BussinessUnits;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.BussinessUnits;
public interface IBussinessUnitRepository : ICrudRepository<BussinessUnit, BussinessUnitQuery>
{
}
