
using DefaultTemplate.Domain.Common;

namespace DefaultTemplate.DataAccess.Entities.Base;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}

public class EnumEntity : IEntity<string>
{
    public string Id { get; set; }
    public Localizable Name { get; set; }
}

public class NamedEntity : BaseEntity
{
    public Localizable Name { get; set; }
}