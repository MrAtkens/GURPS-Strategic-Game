using DefaultTemplate.Domain.Common;
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Models.Roles;

namespace DefaultTemplate.Domain;

public static class Fields
{
    public static string FullName = "FullName";
    public static string Type = "Type";
}
public static class Permissions
{
    public static EPermission View = new()
    {
        Id = "view",
        Name = new Localizable("Просмотр карты", "Просмотр карты", "Просмотр карты"),
    };
    public static EPermission[] List = { View };
}

public static class Roles
{
    public static Role Business = new()
    {
        Id = new Guid("f033867b-1799-4e8c-b284-b475aed4d89a"),
        Name = new Localizable("Бизнес","Бизнес","Бизнес"),
    };

    public static Role Waiter = new()
    {
        Id = new Guid("a5320e38-a575-4970-be64-28530b0c8c81"),
        Name = new Localizable("Официант","Официант","Официант"),
    };
    
    public static Role[] List = { Business, Waiter };
}

