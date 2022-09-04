using AutoMapper;
using DefaultTemplate.DataAccess.Entities.OrgStructures;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.IndividualEntrepreneurs;

namespace DefaultTemplate.DataAccess.Mapping;
public class IndividualEntrepreneurMapping : Profile
{
    public IndividualEntrepreneurMapping()
    {
        CreateMap<IndividualEntrepreneurEntity, IndividualEntrepreneur>()
            .ForMember(dest => dest.CreatedBy, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.ModifiedBy, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(x => x.NatPerson.BirthDay))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.NatPerson.FullName))
            .ForMember(dest => dest.ParticipantId, opt => opt.MapFrom(x => x.NatPerson.ParticipantId))
            .ForMember(dest => dest.BusinessCode, opt => opt.MapFrom(x => x.NatPerson.Participant.BusinessCode))
            .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(x => x.NatPerson.Participant.CountryCode))
            .ForMember(dest => dest.ParticipantTypeId, opt => opt.MapFrom(x => x.NatPerson.Participant.ParticipantTypeId))
            .ForMember(dest => dest.ParticipantType, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.ParticipantType, opt => opt.MapFrom(x => x.NatPerson.Participant.ParticipantType))
            .ForMember(dest => dest.ParticipantActivities, opt => opt.ExplicitExpansion())
            .ForMember(dest => dest.ParticipantActivities, opt => opt.MapFrom(x => x.NatPerson.Participant.ParticipantActivities));
        CreateMap<IndividualEntrepreneurEntity, BaseModel>();

    }
}
