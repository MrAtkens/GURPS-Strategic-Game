using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories.Enums
{
    public class RemarkNameTypeRepository : EnumRepository<ERemarkNameType, RemarkNameTypeEntity>
    {
        public RemarkNameTypeRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
        {
        }

        protected override void Update(ERemarkNameType model, RemarkNameTypeEntity entity)
        {
            entity.Name = model.Name!;
        }
    }
}
