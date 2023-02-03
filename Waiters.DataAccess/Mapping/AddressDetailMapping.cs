using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Entities.Users.UserInfo;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.DataAccess.Mapping;
public class AddressDetailsMapping : Profile
{
    public AddressDetailsMapping()
    {
        CreateMap<AddressDetailEntity, AddressDetail>()
            .ForMember(dest => dest.CreatedBy, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.ModifiedBy, opt => opt.ExplicitExpansion());
        CreateMap<AddressDetailEntity, BaseModel>();
    }
}