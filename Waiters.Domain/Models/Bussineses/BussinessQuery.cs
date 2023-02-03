using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Models.Bussineses;

public class BussinessQuery : SearchQuery
{
    public string? Bin { get; set; }
    public Guid? ParentId { get; set; }
    public string? Mail { get; set; }
}