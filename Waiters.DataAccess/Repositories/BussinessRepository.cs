using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain;
using DefaultTemplate.Domain.Models.Bussineses;
using DefaultTemplate.Domain.Models.Users;
using DefaultTemplate.Domain.Services.Bussineses;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.Users;

namespace DefaultTemplate.DataAccess.Repositories;

public class BussinesRepository: BaseRepository<Business, BussinessEntity, BussinessQuery>, IBussinessRepository
{
    private IUserRepository _userRepository;

    public BussinesRepository(DefaultContext context, IMapper mapper, IContextService contextService, IUserRepository userRepository) : base(context, mapper, contextService)
    {
        _userRepository = userRepository;
    }
    protected override void Update(BussinessEntity entity, Business model)
    {
        entity.Bin = model.Bin;
        entity.RegistrationDate = model.RegistrationDate;
        entity.ParentId = model.ParentId;
        entity.UserId = model.UserId;
    }
    
    public override async Task SaveAsync(Business model, bool forceId = false)
    {
        var entity = _dbSet.FirstOrDefault(x => x.Id == model.Id);
        var isAdd = false;
        if (entity == null)
        {
            entity = CreateNew(model);
            entity.CreateById = _contextService.CurrentUser.Id;

            entity.Id = forceId ? model.Id : Guid.NewGuid();
            model.Id = entity.Id;
            model.User = new User()
            {
                Id = Guid.NewGuid(),
                Name = model.User.Name,
                LoginMail = model.User.LoginMail,
                Password = model.User.Password,
                RoleId = Roles.Business.Id,
                AddressDetails = model.User.AddressDetails,
                ContactDetails = model.User.ContactDetails
            };
            model.UserId = model.User.Id;
            isAdd = true;
        }
        if(model.User != null)
            await _userRepository.SaveAsync(model.User, true);
        Update(entity, model);
        entity.ModifiedById = _contextService.CurrentUser.Id;

        if (isAdd) _dbSet.Add(entity);
    }

    protected override IQueryable<BussinessEntity> Search(IQueryable<BussinessEntity> dbQuery, BussinessQuery query)
    {
        if (query.Ids?.Any() == true)
            dbQuery = dbQuery.Where(x => query.Ids.Contains(x.Id));
        if (query.ExcludeIds?.Any() == true)
            dbQuery = dbQuery.Where(x => !query.ExcludeIds.Contains(x.Id));
        if (!string.IsNullOrWhiteSpace(query.Mail))
            dbQuery = dbQuery.Where(x => x.User != null && x.User.LoginMail == query.Mail);
        
        return dbQuery;
    }

}