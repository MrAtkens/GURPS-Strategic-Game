using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Users;

namespace DefaultTemplate.DataAccess.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserEntity, User>()
            .ForMember(dest => dest.Password, opt => opt.ExplicitExpansion());
        
        CreateMap<RoleEntity, BaseModel>();
        CreateMap<RoleEntity, NamedModel>();
    }
}