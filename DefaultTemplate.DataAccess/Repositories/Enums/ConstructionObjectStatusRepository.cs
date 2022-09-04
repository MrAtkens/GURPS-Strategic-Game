using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;


namespace DefaultTemplate.DataAccess.Repositories.Enums
{
    public class ConstructionObjectStatusRepository : EnumRepository<EConstructionObjectStatus, ConstructionObjectStatusEntity>
    {
        public ConstructionObjectStatusRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
        {
        }

        protected override void Update(EConstructionObjectStatus model, ConstructionObjectStatusEntity entity)
        {
            entity.Name = model.Name;
        }
    }
}
