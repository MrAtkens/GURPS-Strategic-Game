using Microsoft.Extensions.DependencyInjection;
using DefaultTemplate.Domain;
using DefaultTemplate.Domain.Models;
using DefaultTemplate.Domain.Models.DesignCalendarPlanTaskNames;
using DefaultTemplate.Domain.Models.Common;
using DefaultTemplate.Domain.Models.ConstructionObjectCategories;
using DefaultTemplate.Domain.Models.ConstructionTypes;
using DefaultTemplate.Domain.Models.DesignAssignmentPartitionTypes;
using DefaultTemplate.Domain.Models.Enums;
using DefaultTemplate.Domain.Models.FinancingSources;
using DefaultTemplate.Domain.Models.RefLists;
using DefaultTemplate.Domain.Services.DesignCalendarPlanTaskNames;
using DefaultTemplate.Domain.Services.Common;
using DefaultTemplate.Domain.Services.ConstructionObjectCategories;
using DefaultTemplate.Domain.Services.ConstructionTypes;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.DesignAssignmentPartitionTypes;
using DefaultTemplate.Domain.Services.FinancingSources;
using DefaultTemplate.Domain.Services.RefLists;
using DefaultTemplate.Domain.PredefinedData;
using DefaultTemplate.Domain.Services.DocumentKind;
using DefaultTemplate.Domain.Models.DocumentKind;
using DefaultTemplate.Domain.Models.Documents;
using DefaultTemplate.Domain.Models.NotificationTypes;
using DefaultTemplate.Domain.Services.NotificationTypes;
using DefaultTemplate.Domain.Models.DocumentPackages;
using DefaultTemplate.Domain.Models.EnergyEfficiencyClasses;
using DefaultTemplate.Domain.Services.EnergyEfficiencyClasses;
using DefaultTemplate.Domain.Models.TechnicalDifficulties;
using DefaultTemplate.Domain.Services.TechnicalDifficulties;
using DefaultTemplate.Domain.Models.ResponsibilityLevels;
using DefaultTemplate.Domain.Services.ResponsibilityLevels;
using DefaultTemplate.Domain.Models.ConstructionIndustries;
using DefaultTemplate.Domain.Services.ConstructionIndustries;
using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Services.AddressDetails;
using DefaultTemplate.Domain.Models.ContactDetails;
using DefaultTemplate.Domain.Services.ContactDetails;
using DefaultTemplate.Domain.Models.PostTypes;
using DefaultTemplate.Domain.Services.NatPersons;
using DefaultTemplate.Domain.Services.Banks;
using DefaultTemplate.Domain.Models.Banks;
using DefaultTemplate.Domain.Services.BankAccounts;
using DefaultTemplate.Domain.Models.BankAccounts;
using DefaultTemplate.Domain.Models.ParticipantActivitiesTypes;
using DefaultTemplate.Domain.Services.ParticipantActivitiesTypes;
using DefaultTemplate.Domain.Models.Companies;
using DefaultTemplate.Domain.Services.Companies;
using DefaultTemplate.Domain.Models.BussinessUnits;
using DefaultTemplate.Domain.Services.BussinessUnits;
using DefaultTemplate.Domain.Models.Employees;
using DefaultTemplate.Domain.Services.Employees;
using DefaultTemplate.Domain.Services.Participants;
using DefaultTemplate.Domain.Services.InfoPortal.Contacts;
using DefaultTemplate.Domain.Models.InfoPortal.Contacts;
using DefaultTemplate.Domain.Models.Participants;
using DefaultTemplate.Domain.Models.NatPersons;
using DefaultTemplate.Domain.Models.CurrentUser;
using DefaultTemplate.Domain.Services.Roles;
using DefaultTemplate.Domain.Models.Roles;

namespace DefaultTemplate.DataAccess;

public class DataInitializer
{
    private readonly IServiceProvider _services;

    public DataInitializer(IServiceProvider services)
    {
        _services = services;
    }

    public async Task Init()
    {
        var unitOfWork = _services.GetRequiredService<IUnitOfWork>();
        var contextService = _services.GetRequiredService<IContextService>() as HttpContextService;
        var natPersonRepository = _services.GetRequiredService<INatPersonRepository>();
        var participantRepository = _services.GetRequiredService<IParticipantRepository>();
        contextService.CurrentUser = CurrentUser.NatPersonToCurrentUser(NatPersons.SysUser);

        await SaveEnum<IEnumRepository<EProjectStatus>, EProjectStatus>(EProjectStatus.All);
        await SaveEnum<IEnumRepository<EEntityType>, EEntityType>(EEntityType.All);
        await SaveEnum<IEnumRepository<ERemarkNameType>, ERemarkNameType>(ERemarkNameType.All);
        await SaveEnum<IEnumRepository<ERemarkStatus>, ERemarkStatus>(ERemarkStatus.All);
        await SaveEnum<IEnumRepository<EDesignCalendarPlanTaskStatus>, EDesignCalendarPlanTaskStatus>(EDesignCalendarPlanTaskStatus.All);

        await SaveEnum<IEnumRepository<EConstructionObjectStatus>, EConstructionObjectStatus>(EConstructionObjectStatus.All);
        await SaveEnum<IEnumRepository<EDevelopmentStep>, EDevelopmentStep>(EDevelopmentStep.All);
        await SaveEnum<IEnumRepository<EDevelopmentStage>, EDevelopmentStage>(EDevelopmentStage.All);
        await SaveEnum<IEnumRepository<EWorkStep>, EWorkStep>(EWorkStep.All);
        await SaveEnum<IEnumRepository<EDocumentVersionStatus>, EDocumentVersionStatus>(EDocumentVersionStatus.All);
        await SaveEnum<IEnumRepository<EDocumentType>, EDocumentType>(EDocumentType.All);
        await SaveEnum<IEnumRepository<ENotificationStatus>, ENotificationStatus>(ENotificationStatus.All);
        await SaveEnum<IEnumRepository<EDocumentPackageKind>, EDocumentPackageKind>(EDocumentPackageKind.All);
        await SaveEnum<IEnumRepository<EContactDetailType>, EContactDetailType>(EContactDetailType.All);
        await SaveEnum<IEnumRepository<EActivityTypeEnum>, EActivityTypeEnum>(EActivityTypeEnum.All);
        await SaveEnum<IEnumRepository<EParticipantType>, EParticipantType>(EParticipantType.All);
        await SaveEnum<IEnumRepository<EUnitType>, EUnitType>(EUnitType.All);
        await SaveEnum<IEnumRepository<ELocale>, ELocale>(ELocale.All);
        await SaveEnum<IEnumRepository<EPermission>, EPermission>(EPermission.All);
        await SaveEnum<IEnumRepository<EWorkgroupLinkedType>, EWorkgroupLinkedType>(EWorkgroupLinkedType.All);

        if (await participantRepository.Count(new ParticipantQuery() { Take = 2 }) == 0)
        {
            await Save<IParticipantRepository, Participant, ParticipantQuery>(Participants.List);
            await Save<INatPersonRepository, NatPerson, NatPersonQuery>(NatPersons.List);
            await unitOfWork.SaveChangesAsync();
            await Save<IRoleRepository, Role, RoleQuery>(Roles.List);
            await unitOfWork.SaveChangesAsync();
            natPersonRepository.SetIntitialRoles(new List<Guid>() { Roles.Operator.Id, Roles.Signer.Id }, NatPersons.SysUser);
            await Save<IParticipantActivitiesTypeRepository, ParticipantActivitiesType, ParticipantActivitiesTypeQuery>(ParticipantActivitiesTypes.List);
            await unitOfWork.SaveChangesAsync();
            participantRepository.SetIntitialActivities(new List<Guid>() { ParticipantActivitiesTypes.Operator.Id, ParticipantActivitiesTypes.Signer.Id }, Participants.SysUser);
        }
        await Save<IRefListRepository, RefList, RefListQuery>(Lists.List);
        await Save<IAddressDetailRepository, AddressDetail, AddressDetailQuery>(AddressDetails.List);
        await Save<IContactDetailRepository, ContactDetail, ContactDetailQuery>(ContactDetails.List);
        await Save<IFinancingSourceRepository, FinancingSource, FinancingSourceQuery>(FinancingSources.List);
        await Save<IConstructionObjectCategoryRepository, ConstructionObjectCategory, ConstructionObjectCategoryQuery>(ConstructionObjectCategories.List);
        await Save<IConstructionTypeRepository, ConstructionType, ConstructionTypeQuery>(ConstructionTypes.List);
        await Save<IPostTypeRepository, PostType, PostTypeQuery>(PostTypes.List);
        await Save<IEmployeeRepository, Employee, EmployeeQuery>(Employees.List);
        await Save<IBankRepository, Bank, BanksQuery>(Banks.List);
        await Save<IBankAccountRepository, BankAccount, BankAccountQuery>(BankAccounts.List);
        await Save<ICompanyRepository, Company, CompanyQuery>(Companies.List);
        await Save<IBussinessUnitRepository, BussinessUnit, BussinessUnitQuery>(BussinessUnits.List);

        await Save<IDesignAssignmentPartitionTypeRepository, DesignAssignmentPartitionType, DesignAssignmentPartitionTypeQuery>(ConstantDesignAssignmentPartitionTypes.List);
        await Save<IDesignCalendarPlanTaskNameRepository, DesignCalendarPlanTaskName, DesignCalendarPlanTaskNameQuery>(ConstantDesignCalendarPlanTaskNames.List);
        await Save<IDocumentKindRepository, DocumentKind, DocumentKindQuery>(ConstantDocumentKinds.List);
        await Save<INotificationTypeRepository, NotificationType, NotificationTypeQuery>(ConstantNotificationTypes.List);
        await Save<IEnergyEfficiencyClassRepository, EnergyEfficiencyClass, EnergyEfficiencyClassQuery>(ConstantEnergyEfficiencyClass.List);
        await Save<ITechnicalDifficultyRepository, TechnicalDifficulty, TechnicalDifficultyQuery>(ConstantTechnicalDifficulty.List);
        await Save<IResponsibilityLevelRepository, ResponsibilityLevel, ResponsibilityLevelQuery>(ConstantResponsibilityLevel.List);
        await Save<IConstructionIndustryRepository, ConstructionIndustry, ConstructionIndustryQuery>(ConstantConstructionIndustries.List);

        await unitOfWork.SaveChangesAsync();
    }

    async Task Save<TRepository, TDomain, TQuery>(IReadOnlyList<TDomain> models)
        where TRepository : ICrudRepository<TDomain, TQuery>
        where TDomain : BaseModel
        where TQuery : SearchQuery
    {
        var rep = _services.GetRequiredService<TRepository>();
        foreach (var model in models)
        {
            await rep.SaveAsync(model, true);
        }
        
    }
    
    async Task SaveEnum<TRepository, TEnum>(IReadOnlyList<TEnum> models)
        where TRepository : IEnumRepository<TEnum>
        where TEnum : EnumModel
    {
        var rep = _services.GetRequiredService<TRepository>();
        foreach (var model in models)
        {
            await rep.Save(model);
        }
    }
}