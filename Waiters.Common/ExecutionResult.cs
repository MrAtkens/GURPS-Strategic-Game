using DefaultTemplate.Common.Enums;

namespace DefaultTemplate.Common;

public class ExecutionResult<TData> where TData: class
{
    public DefaultResult Code { get; set; }
    public TData? Data { get; set; }
}

public class ExecutionResult : ExecutionResult<object> {}