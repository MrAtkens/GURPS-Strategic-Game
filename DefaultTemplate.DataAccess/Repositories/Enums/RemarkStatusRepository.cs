using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories.Enums
{
    public class RemarkStatusRepository : EnumRepository<ERemarkStatus, RemarkStatusEntity>
    {
        public RemarkStatusRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
        {
        }

        protected override void Update(ERemarkStatus model, RemarkStatusEntity entity)
        {
            entity.Name = model.Name;
        }
    }
}
