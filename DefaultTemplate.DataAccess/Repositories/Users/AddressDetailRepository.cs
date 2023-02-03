using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Services.AddressDetails;
using DefaultTemplate.Domain.Services.ContextService;

namespace DefaultTemplate.DataAccess.Repositories.Users;

public class AddressDetailRepository : BaseRepository<AddressDetail, AddressDetailEntity, AddressDetailQuery>, IAddressDetailRepository
{
    public AddressDetailRepository(DefaultContext context, IMapper mapper, IContextService contextService) : base(context, mapper, contextService)
    {
    }

    protected override void Update(AddressDetailEntity entity, AddressDetail model)
    {
        entity.Value = model.Value;
        entity.Type = model.Type;
        entity.Lat = model.Lat;
        entity.Lng = model.Lng;
    }

}