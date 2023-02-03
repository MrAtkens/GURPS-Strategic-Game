using DefaultTemplate.Domain.Models.Users;

namespace DefaultTemplate.Domain.Models.Bussineses;

public class Business : User
{
    public string Bin { get; set; }
    public Guid? ParentId { get; set; }
    public DateTime RegistrationDate { get; set; }
}