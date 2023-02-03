using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.ContactDetails;

namespace DefaultTemplate.DataAccess.Mapping;

public class ContactDetailMapping : Profile
{
    public ContactDetailMapping()
    {
        CreateMap<ContactDetailEntity, ContactDetail>()
            .ForMember(dest => dest.CreatedBy, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.ModifiedBy, opt => opt.ExplicitExpansion());
        CreateMap<ContactDetailEntity, BaseModel>();
    }
}