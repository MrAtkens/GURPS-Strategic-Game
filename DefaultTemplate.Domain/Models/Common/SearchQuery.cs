namespace DefaultTemplate.Domain.Models.Common;

public class DateRange
{
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
}

public class SearchQuery
{
    public Guid[]? Ids { get; set; }
    public Guid[]? ExcludeIds { get; set; }
    public string[] Includes { get; set; } = Array.Empty<string>();
    public int Skip { get; set; }
    public int Take { get; set; }
    public DateTimeOffset? StartDate { get; set; }
}