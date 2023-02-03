using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Waiters;

namespace DefaultTemplate.DataAccess.Mapping;

public class WaiterMapping : Profile
{
    public WaiterMapping()
    {
        CreateMap<WaiterEntity, Waiter>()
            .ForMember(dest => dest.User, opt => opt.ExplicitExpansion());
            
        CreateMap<WaiterEntity, BaseModel>();
        CreateMap<WaiterEntity, NamedModel>();
    }
}