using DefaultTemplate.Domain.Common;
using DefaultTemplate.Domain.Models.ConstructionIndustries;

namespace DefaultTemplate.Domain.PredefinedData;
public static class ConstantConstructionIndustries
{

    public static ConstructionIndustry Commercial = new()
    {
        Id = new Guid("12f7a1f9-1eda-4551-a26a-43aa7599f47c"),
        DateStart = DateTimeOffset.Now,
        Name = new Localizable(
       "Commercial", "Коммерческая", "Коммерческая")
    };

    public static ConstructionIndustry[] List = { Commercial };
}
