using FluentValidation;
using DefaultTemplate.Common.Enums;
using DefaultTemplate.Common.Exceptions;
using DefaultTemplate.Domain.Models.BussinessUnits;
using DefaultTemplate.Domain.Services.Common;

namespace DefaultTemplate.Domain.Services.BussinessUnits;
public class BussinessUnitService : BaseService<BussinessUnit, BussinessUnitQuery>, IBussinessUnitService
{
    protected override AbstractValidator<BussinessUnit>? Validator => new BussinessUnitValidator();

    public BussinessUnitService(IBussinessUnitRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public override async Task SaveAsync(BussinessUnit model, bool forceId = false, bool commit = true)
    {
        if(model.RootId == null && model.ParentId != null)
        {
            model.RootId = model.ParentId;
        }
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

    public override async Task Delete(Guid id)
    {
        var childs = await _repository.SearchAsync(new BussinessUnitQuery { ParentId = id, Take = int.MaxValue });
        if (childs.Total > 0)
        {
            string units = "";
            foreach(var item in childs.Data)
            {
                units += $"{item.Name.Ru} ";
            }
            throw new ExecutionResultException(GbimResult.IncorrectData, $"Вы не можете удалить " +
                $"данный узел так как у него есть дочерний объекты в количестве {childs.Total}." +
                $"Вам нужно удалить {units}");
        }
        await _repository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
