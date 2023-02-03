using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Models.Waiters;

public class WaiterQuery : SearchQuery
{
    public double? RatingFrom { get; set; }
    public double? RatingTo { get; set; }
    public string? Mail { get; set; }
}