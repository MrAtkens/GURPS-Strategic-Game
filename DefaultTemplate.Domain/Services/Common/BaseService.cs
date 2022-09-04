using FluentValidation;
using FluentValidation.Results;
using DefaultTemplate.Common.Enums;
using DefaultTemplate.Common.Exceptions;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Services.Common;

public class BaseService<TDomain, TSearchQuery> : ICrudService<TDomain, TSearchQuery>
    where TDomain : class
    where TSearchQuery : SearchQuery 
{
    protected readonly ICrudRepository<TDomain, TSearchQuery> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected virtual AbstractValidator<TDomain>? Validator { get => null; }

    public BaseService(ICrudRepository<TDomain, TSearchQuery> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task<TDomain?> GetAsync(Guid id) => _repository.GetAsync(id);

    public Task<IReadOnlyList<TDomain>> GetListAsync(TSearchQuery query) => _repository.GetAsync(query);
    public Task<SearchResult<TDomain>> SearchAsync(TSearchQuery query) => _repository.SearchAsync(query);

    public Task<TDomain?> FirstOrDefault(TSearchQuery query) => _repository.FirstOrDefault(query);

    public virtual async Task SaveAsync(TDomain model, bool forceId = false, bool commit = true)
    {
        var validateResult = Validator?.Validate(model);
        if (validateResult?.IsValid == false) 
            throw new ExecutionResultException(GbimResult.IncorrectData, validateResult.Errors[0].ErrorMessage, validateResult.Errors[0].PropertyName);

        await Validate(model);
        await _repository.SaveAsync(model, forceId);
        await OnSaved(model);

        if (commit)
        {
            await _unitOfWork.SaveChangesAsync();
            await OnCommited(model);
        }
    }

    public virtual async Task Delete(Guid id)
    {
        await _repository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> Any(TSearchQuery searchQuery)
    {
        return await _repository.Any(searchQuery);
    }

    public async Task<int> Count(TSearchQuery searchQuery)
    {
        return await _repository.Count(searchQuery);
    }

    public virtual async Task Validate(TDomain model)
    {

    }

    protected async Task ValidateUsageAsync<TDom, TSearch>(Guid id) where TDom : class
        where TSearch : SearchQuery, new()
    {
        var repository = _unitOfWork.GetRepository<TDom, TSearch>();
        var search = new TSearch() { Ids = new Guid[] { id } };
        if (await repository.Any(search) == false)
            throw new ExecutionResultException(GbimResult.IncorrectData, $"Данный id не может использоваться потом что он не был найден {id}");
    }

    protected virtual Task OnSaved(TDomain model) => Task.CompletedTask;

    protected virtual Task OnCommited(TDomain model) => Task.CompletedTask;

    protected async Task TryCreate<T, TQuery>(T model, TQuery query, ICrudService<T, TQuery> service)
        where T : BaseModel
        where TQuery : SearchQuery
    {
        var existModel = await service.FirstOrDefault(query);
        if (existModel is null)
            await service.SaveAsync(model, false, false);
        else
            model.Id = existModel.Id;
    }
}