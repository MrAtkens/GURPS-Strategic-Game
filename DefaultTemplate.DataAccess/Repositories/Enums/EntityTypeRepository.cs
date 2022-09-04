using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;


namespace DefaultTemplate.DataAccess.Repositories.Enums
{
    public class EntityTypeRepository : EnumRepository<EEntityType, EntityTypeEntity>
    {
        public EntityTypeRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
        {
        }

        protected override void Update(EEntityType model, EntityTypeEntity entity)
        {
            entity.Name = model.Name;
        }
    }
}
