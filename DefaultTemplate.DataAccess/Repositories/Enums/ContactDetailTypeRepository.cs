

using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories.Enums;
public class ContactDetailTypeRepository : EnumRepository<EContactDetailType, ContactDetailTypeEntity>
{
    public ContactDetailTypeRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
    {
    }

    protected override void Update(EContactDetailType model, ContactDetailTypeEntity entity)
    {
        entity.Name = model.Name;
    }
}