
using DefaultTemplate.Domain.Models.Common;

namespace DefaultTemplate.Domain.Models.Users;

public class UserQuery : SearchQuery
{
    public string? Mail { get; set; }
}