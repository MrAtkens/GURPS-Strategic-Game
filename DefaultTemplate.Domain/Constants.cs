using DefaultTemplate.Domain.Common;

namespace DefaultTemplate.Domain;

public static class Fields
{
    public static string FullName = "FullName";
    public static string Type = "Type";
}
public static class Banks
{
    public static Bank Bank = new()
    {
        Id = new Guid("28a08518-4d1d-4f57-bd3b-396b99f5ab3a"),
        Name = new Localizable("Bank", "Bank", "Bank"),
        Bin = "123",
        Bic = "BANK",
        DateStart = DateTimeOffset.Now
    };
    public static Bank[] List = { Bank };
}

public static class BankAccounts
{
    public static BankAccount Bank = new()
    {
        Id = new Guid("f68c9acf-68ee-4ef0-b791-07887bc687e5"),
        Number = "342",
        ParticipantId = Participants.SysUser.Id,
        isDefault = true,
        BankId = Banks.Bank.Id
    };
    public static BankAccount[] List = { Bank };
}

