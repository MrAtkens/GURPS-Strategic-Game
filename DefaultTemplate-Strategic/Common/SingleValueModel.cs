namespace DefaultTemplate.Api.Common;

public class SingleValueModel<TValue>
{
    public SingleValueModel() {}

    public SingleValueModel(TValue val)
    {
        Value = val;
    }

    public TValue? Value { get; set; }
}