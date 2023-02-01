using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using DefaultTemplate.Common.Enums;
using DefaultTemplate.Common.Exceptions;
using DefaultTemplate.DataAccess.Entities.Base;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Services.Common;
using DefaultTemplate.Domain.Services.System;

namespace DefaultTemplate.DataAccess.Repositories.Base;

public class BaseRepository<TDomain, TEntity, TSearchQuery> : ICrudRepository<TDomain, TSearchQuery> 
    where TDomain : BaseModel
    where TEntity : BaseEntity, new()
    where TSearchQuery : SearchQuery 
{
    protected readonly DefaultContext _context;
    protected readonly IMapper _mapper;
    protected readonly IContextService _contextService;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DefaultContext context, IMapper mapper, IContextService contextService)
    {
        _context = context;
        _mapper = mapper;
        _contextService = contextService;
        _dbSet = context.Set<TEntity>();
    }

    public Task<TDomain?> GetAsync(Guid id) => _dbSet.AsNoTracking()
        .Where(x => !x.IsDeleted)
        .ProjectTo(_mapper.ConfigurationProvider, null, IncludeAggregated())
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<TDomain?> FirstOrDefault(TSearchQuery query)
    {
        var dbQuery = GetDbQuery(query);
        return await Search(dbQuery, query).ProjectTo<TDomain>(_mapper.ConfigurationProvider, null, query.Includes).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<TDomain>> GetAsync(TSearchQuery query)
    {
        var dbQuery = GetDbQuery(query);
        return await Search(dbQuery, query).ProjectTo<TDomain>(_mapper.ConfigurationProvider, null, query.Includes).ToListAsync();
    }

    public async Task<SearchResult<TDomain>> SearchAsync(TSearchQuery query)
    {
        var dbQuery = GetDbQuery(query);
        dbQuery = Search(dbQuery, query);

        var total = await dbQuery.CountAsync();
        return new SearchResult<TDomain>
        {
            Total = total,
            Data = await dbQuery.Skip(query.Skip).Take(query.Take)
                .ProjectTo<TDomain>(_mapper.ConfigurationProvider, null, query.Includes).ToListAsync()
        };
    }

    public async Task<bool> Any(TSearchQuery query)
    {
        var dbQuery = GetDbQuery(query);
        return await Search(dbQuery, query).AnyAsync();
    }

    public async Task<int> Count(TSearchQuery query)
    {
        var dbQuery = GetDbQuery(query);
        return await Search(dbQuery, query).CountAsync();
    }

    public virtual Task SaveAsync(TDomain model, bool forceId = false)
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
        
        Update(entity, model);
        entity.ModifiedById = _contextService.CurrentUser.Id;

        if (isAdd) _dbSet.Add(entity);

        return Task.CompletedTask;
    }

    public virtual async Task Delete(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
            throw new ExecutionResultException(DefaultResult.IncorrectData);

        entity.IsDeleted = true;
        entity.DeletedById = _contextService.CurrentUser.Id;
        entity.DeletedDate = DateTimeOffset.Now;
        
        await _context.SaveChangesAsync();
    }

    protected virtual void Update(TEntity entity, TDomain model) {}

    protected virtual IQueryable<TEntity> Search(IQueryable<TEntity> dbQuery, TSearchQuery query)
    {
        if (query.Ids?.Any() == true)
            dbQuery = dbQuery.Where(x => query.Ids.Contains(x.Id));

        return dbQuery;
    }

    protected virtual Expression<Func<TDomain, object>>[] IncludeAggregated() => Array.Empty<Expression<Func<TDomain, object>>>();
    
    protected virtual TEntity CreateNew(TDomain model) => new()
    {
        IsDeleted = false,
        CreatedDate = DateTimeOffset.Now,
        ModifiedDate = DateTimeOffset.Now
    };

    protected virtual IQueryable<TEntity> GetDbQuery(TSearchQuery query)
    {
        return _dbSet.AsNoTracking().Where(x => !x.IsDeleted);
    }
}