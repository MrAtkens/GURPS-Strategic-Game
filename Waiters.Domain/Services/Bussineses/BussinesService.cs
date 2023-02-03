using DefaultTemplate.Domain.Models.Bussineses;
using DefaultTemplate.Domain.Services.Common;
using FluentValidation;

namespace DefaultTemplate.Domain.Services.Bussineses;

public class BussinesService: BaseService<Business, BussinessQuery>, IBussinessService
{
    protected override AbstractValidator<Business>? Validator => new BussinessValidator();

    public BussinesService(IBussinessRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}