using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.Users;

namespace DefaultTemplate.Domain.Models.Bussineses;

public class Business : BaseModel
{
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public string Bin { get; set; }
    public Guid? ParentId { get; set; }
    public DateTime RegistrationDate { get; set; }
}