
using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Base;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Services.ContextService;

namespace DefaultTemplate.DataAccess.Repositories.Base;
public class ReferenceRepository<TDomain, TEntity, TSearchQuery> : BaseRepository<TDomain, TEntity, TSearchQuery>
    where TDomain : ReferenceModel
    where TEntity : BaseReference, new()
    where TSearchQuery : SearchQuery
{
    public ReferenceRepository(GbimContext context, IMapper mapper, IContextService contextService) : base(context, mapper, contextService)
    {
    }

    public override Task SaveAsync(TDomain model, bool forceId = false)
    {
        var entity = _dbSet.FirstOrDefault(x => x.Id == model.Id);
        var isAdd = false;
        if (entity == null)
        {
            entity = CreateNew(model);
            entity.CreateById = _contextService.CurrentUser.Id;

            entity.Id = forceId ? model.Id : Guid.NewGuid();
            model.Id = entity.Id;

            isAdd = true;
        }

        entity.DateStart = model.DateStart;
        entity.DateEnd = model.DateEnd;
        entity.RefHistory = model.RefHistory;
        Update(entity, model);
        entity.ModifiedById = _contextService.CurrentUser.Id;

        if (isAdd) _dbSet.Add(entity);

        return Task.CompletedTask;
    }

    protected override IQueryable<TEntity> Search(IQueryable<TEntity> dbQuery, TSearchQuery query)
    {
        if(query.StartDate != null)
            dbQuery = dbQuery.Where(x => x.DateStart < query.StartDate && (x.DateEnd > query.StartDate || x.DateEnd == null));
        if (query.Ids?.Any() == true)
            dbQuery = dbQuery.Where(x => query.Ids.Contains(x.Id));        
        return dbQuery;
    }

}
