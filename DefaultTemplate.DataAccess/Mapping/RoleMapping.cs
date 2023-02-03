using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Models.Roles;

namespace DefaultTemplate.DataAccess.Mapping;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<RoleEntity, Role>();
        CreateMap<RoleEntity, BaseModel>();
        CreateMap<RoleEntity, NamedModel>();
        CreateMap<RolePermissionEntity, EPermission>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Permission.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Permission.Name))
            .ForMember(x => x.Parent, opt => opt.MapFrom(x => x.Permission.Parent))
            .ForMember(x => x.ParentId, opt => opt.MapFrom(x => x.Permission.ParentId));

    }
}