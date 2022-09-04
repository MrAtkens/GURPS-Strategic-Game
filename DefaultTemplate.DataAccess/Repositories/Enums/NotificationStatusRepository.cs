using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;


namespace DefaultTemplate.DataAccess.Repositories.Enums
{
    public class NotificationStatusRepository : EnumRepository<ENotificationStatus, NotificationStatusEntity>
    {
        public NotificationStatusRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
        {
        }

        protected override void Update(ENotificationStatus model, NotificationStatusEntity entity)
        {
            entity.Name = model.Name;
        }
    }
}
