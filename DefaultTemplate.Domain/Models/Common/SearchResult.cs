namespace DefaultTemplate.Domain.Models.Common;

public class SearchResult<TModel>
{
    public IReadOnlyList<TModel> Data { get; set; } = null!;
    public long Total { get; set; }
}