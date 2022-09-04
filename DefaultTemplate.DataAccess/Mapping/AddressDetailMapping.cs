using AutoMapper;
using DefaultTemplate.DataAccess.Entities.OrgStructure;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.AddressDetails;

namespace DefaultTemplate.DataAccess.Mapping;
public class AddressDetailsMapping : Profile
{
    public AddressDetailsMapping()
    {
        CreateMap<AddressDetailEntity, AddressDetail>()
            .ForMember(dest => dest.CreatedBy, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.ModifiedBy, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.Participant, opt => opt.ExplicitExpansion());
        CreateMap<AddressDetailEntity, BaseModel>();
    }
}