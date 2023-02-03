using DefaultTemplate.Common.Enums;

namespace DefaultTemplate.Common.Exceptions;

public class ExecutionResultException : Exception
{
    public DefaultResult Code { get; }
    public string Field { get; }

    public ExecutionResultException(DefaultResult code, string? msg = null, string? field = null) : base(msg)
    {
        Code = code;
        Field = field;
    }
}