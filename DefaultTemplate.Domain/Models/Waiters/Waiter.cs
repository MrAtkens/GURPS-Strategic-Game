using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Users;

namespace DefaultTemplate.Domain.Models.Waiters;

public class Waiter : BaseModel
{
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public double? Rating { get; set; }
    public DateTime BirthDay { get; set; }
    public string? Avatar { get; set; }
}