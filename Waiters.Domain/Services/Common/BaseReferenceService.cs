using DefaultTemplate.Common.Enums;
using DefaultTemplate.Common.Exceptions;
using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Services.Common;
public class BaseReferenceService<TDomain, TSearchQuery> : BaseService<TDomain, TSearchQuery>
    where TDomain : ReferenceModel
    where TSearchQuery : SearchQuery
{
    public BaseReferenceService(ICrudRepository<TDomain, TSearchQuery> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public override async Task SaveAsync(TDomain model, bool forceId = false, bool commit = true)
    {
        var entity = await _repository.GetAsync(model.Id);
        model.DateStart = DateTimeOffset.Now;
        if (entity != null)
        {
            model.Id = Guid.NewGuid();
            model.DateEnd = null;
            entity.DateEnd = model.DateStart;
            if (entity.RefHistory == null)
                model.RefHistory = entity.Id;
            else
                model.RefHistory = entity.RefHistory;
        }
        var validateResult = Validator?.Validate(model);
        if (validateResult?.IsValid == false)
            throw new ExecutionResultException(DefaultResult.IncorrectData, validateResult.Errors[0].ErrorMessage, validateResult.Errors[0].PropertyName);
        await Validate(model);
        await _repository.SaveAsync(model, forceId);
        await OnSaved(model);
        if (entity != null)
        {
            await _repository.SaveAsync(entity, forceId);
            await OnSaved(entity);
        }

        if (commit)
        {
            await _unitOfWork.SaveChangesAsync();
            await OnCommited(model);
            if(entity != null)
            {
                await _unitOfWork.SaveChangesAsync();
                await OnCommited(entity);
            }
        }
    }
}
