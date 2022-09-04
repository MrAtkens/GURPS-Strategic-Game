using DefaultTemplate.Domain.Models.Enums;
using DefaultTemplate.Domain.Models.NatPersons;
using DefaultTemplate.Domain.Models.ParticipantActivitiesTypes;

namespace DefaultTemplate.Domain.Models.CurrentUser;
public class CurrentUser : NatPerson
{
    public ParticipantActivitiesType CurrentActivity { get; set; }
    public List<EPermission> Permissions { get; set; }
    public static CurrentUser NatPersonToCurrentUser(NatPerson natPerson)
    {
        return new CurrentUser()
        {
            Id = natPerson.Id,
            ParticipantActivities = natPerson.ParticipantActivities,
            ParticipantActivitiesIds = natPerson.ParticipantActivitiesIds,
            ParticipantId = natPerson.ParticipantId,
            ParticipantType = natPerson.ParticipantType,
            ParticipantTypeId = natPerson.ParticipantTypeId,
            BirthDay = natPerson.BirthDay,
            BusinessCode = natPerson.BusinessCode,
            CountryCode = natPerson.CountryCode,
            CreateById = natPerson.CreateById,
            CreatedDate = natPerson.CreatedDate,
            CreatedBy = natPerson.CreatedBy,
            FullName = natPerson.FullName,
            ModifiedBy = natPerson.ModifiedBy,
            ModifiedById = natPerson.ModifiedById,
            ModifiedDate = natPerson.ModifiedDate
        };
    }
}


public class FrontUser : NatPerson
{
    public ParticipantActivitiesType CurrentActivity { get; set; }
    public static FrontUser CurrentUserToFrontUser(CurrentUser currentUser)
    {
        return new FrontUser()
        {
            Id = currentUser.Id,
            ParticipantActivities = currentUser.ParticipantActivities,
            ParticipantActivitiesIds = currentUser.ParticipantActivitiesIds,
            ParticipantId = currentUser.ParticipantId,
            ParticipantType = currentUser.ParticipantType,
            ParticipantTypeId = currentUser.ParticipantTypeId,
            BirthDay = currentUser.BirthDay,
            BusinessCode = currentUser.BusinessCode,
            CountryCode = currentUser.CountryCode,
            CreateById = currentUser.CreateById,
            CreatedDate = currentUser.CreatedDate,
            CreatedBy = currentUser.CreatedBy,
            FullName = currentUser.FullName,
            CurrentActivity = currentUser.CurrentActivity,
            ModifiedBy = currentUser.ModifiedBy,
            ModifiedById = currentUser.ModifiedById,
            ModifiedDate = currentUser.ModifiedDate
        };
    }
}