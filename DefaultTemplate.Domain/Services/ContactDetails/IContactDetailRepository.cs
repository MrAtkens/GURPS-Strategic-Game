using DefaultTemplate.Domain.Models.ContactDetails;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.ContactDetails;

public interface IContactDetailRepository : ICrudRepository<ContactDetail, ContactDetailQuery>
{
    
}