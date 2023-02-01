using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.ContactDetails;
using DefaultTemplate.Domain.Services.ContactDetails;
using DefaultTemplate.Domain.Services.System;

namespace DefaultTemplate.DataAccess.Repositories;

public class ContactDetailRepository : BaseRepository<ContactDetail, ContactDetailEntity, ContactDetailQuery>, IContactDetailRepository
{
    public ContactDetailRepository(DefaultContext context, IMapper mapper, IContextService contextService) : base(context, mapper, contextService)
    {
    }

    protected override void Update(ContactDetailEntity entity, ContactDetail model)
    {
        entity.Value = model.Value;
        entity.Type = model.Type;
    }

}