using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories.Enums;

public class WorkgroupLinkedTypeRepository : EnumRepository<EWorkgroupLinkedType, WorkgroupLinkedTypeEnumEntity>
{
    public WorkgroupLinkedTypeRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
    {
    }

    protected override void Update(EWorkgroupLinkedType model, WorkgroupLinkedTypeEnumEntity entity)
    {
        entity.Name = model.Name;
    }
}
