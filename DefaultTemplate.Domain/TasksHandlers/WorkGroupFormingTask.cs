using Camunda.Api.Client.UserTask;

namespace DefaultTemplate.Domain.TasksHandlers;

public class WorkGroupFormingTaskModel
{
    public string UserId { get; set; }
    public int Num { get; set; }
}

public class TaskHandler<TModel> : ITaskHandler<TModel>, ITaskHandler
    where TModel : class
{
    public Type GetProccesedType() => typeof(TModel);

    public virtual Task<CompleteTask> Handle(TModel model)
    {
        throw new NotImplementedException();
    }

    public Task<CompleteTask> Handle(object model)
    {
        TModel? value = model as TModel;
        if (value == null)
            throw new InvalidCastException($"Cannont cast model to {typeof(TModel)}");

        return Handle(value);
    }
}

public class WorkGroupFormingTaskHandler : TaskHandler<WorkGroupFormingTaskModel[]>
{
    public override Task<CompleteTask> Handle(WorkGroupFormingTaskModel[] model)
    {
        return Task.FromResult(new CompleteTask().SetVariable("workGroup", model));
    }
}
