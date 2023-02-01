using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using DefaultTemplate.DataAccess.Entities.Base;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.DataAccess.Repositories.Base;

public class EnumRepository<TEnum, TEnumEntity> : IEnumRepository<TEnum> where TEnum : EnumModel
    where TEnumEntity : EnumEntity, new()
{
    protected readonly IMapper _mapper;

    protected readonly DbSet<TEnumEntity> _dbSet;
    
    public EnumRepository(DefaultContext context, IMapper mapper)
    {
        _mapper = mapper;
        _dbSet = context.Set<TEnumEntity>();
    }

    public async Task<IReadOnlyList<TEnum>> GetAllAsync()
        => await _dbSet.AsNoTracking().ProjectTo<TEnum>(_mapper.ConfigurationProvider).ToListAsync();

    public async Task Save(TEnum model)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
        var isAdd = false;
        if (entity is null)
        {
            isAdd = true;
            entity = new TEnumEntity
            {
                Id = model.Id
            };
        }

        entity.Name = model.Name;
        Update(model, entity);

        if (isAdd)
            _dbSet.Add(entity);
    }

    protected virtual void Update(TEnum model, TEnumEntity entity) { }
}