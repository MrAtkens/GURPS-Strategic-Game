using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories.Enums
{
    public class DesignCalendarPlanTaskStatusRepository : EnumRepository<EDesignCalendarPlanTaskStatus, DesignCalendarPlanTaskStatusEntity>
    {
        public DesignCalendarPlanTaskStatusRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
        {
        }

        protected override void Update(EDesignCalendarPlanTaskStatus model, DesignCalendarPlanTaskStatusEntity entity)
        {
            entity.Name = model.Name;
        }
    }
}
