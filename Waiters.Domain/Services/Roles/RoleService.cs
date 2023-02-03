using DefaultTemplate.Domain.Models.Roles;
using DefaultTemplate.Domain.Services.Common;
using FluentValidation;

namespace DefaultTemplate.Domain.Services.Roles;

public class RoleService : BaseService<Role, RoleQuery>, IRoleService
{
    protected override AbstractValidator<Role>? Validator => new RoleValidator();

    public RoleService(IRoleRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task Delete(Guid id)
    {
        var role = await _repository.GetAsync(id);
        /*var workPlaces = await _workPlaceRepository.SearchAsync(new WorkPlaceQuery { RoleId = role.Id, Take = 3 });
        if (workPlaces.Total > 0)
            throw new ExecutionResultException(GbimResult.IncorrectData, $"Вы не можете удалить " +
                                                                         $"данную роль потому что на него назначено {workPlaces.Total} рабочих мест");*/
        await _repository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }
}