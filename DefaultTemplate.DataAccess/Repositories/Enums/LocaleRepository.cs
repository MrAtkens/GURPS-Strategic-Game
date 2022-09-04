using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories.Enums;

public class LocaleRepository : EnumRepository<ELocale, LocaleEntity>
{
    public LocaleRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
    {
    }

    protected override void Update(ELocale model, LocaleEntity entity)
    {
        entity.Name = model.Name;
    }
}