using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Entities.Users.UserInfo;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Permissions;

namespace DefaultTemplate.DataAccess.Mapping;

public class PermissionMapping : Profile
{
    public PermissionMapping()
    {
        CreateMap<PermissionEntity, EPermission>()
            .ForMember(dest => dest.Roles, opt => opt.ExplicitExpansion());
        CreateMap<PermissionEntity, BaseModel>();
        CreateMap<PermissionEntity, NamedModel>();
    }
}