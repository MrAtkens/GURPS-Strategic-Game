namespace DefaultTemplate.Common;

public class SingleValueModel<TValue>
{
    public SingleValueModel() {}

    public SingleValueModel(TValue val)
    {
        Value = val;
    }

    private TValue? Value { get; set; }
}