using Camunda.Api.Client.UserTask;

namespace DefaultTemplate.Domain.TasksHandlers;

public interface ITaskHandler
{
    Type GetProccesedType();
    Task<CompleteTask> Handle(object model);
}

public interface ITaskHandler<TModel>
{
    Task<CompleteTask> Handle(TModel model);
}
