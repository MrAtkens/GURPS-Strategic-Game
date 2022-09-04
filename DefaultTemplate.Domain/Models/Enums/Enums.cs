using DefaultTemplate.Domain.Common;
using DefaultTemplate.Domain.Models.Roles;

namespace DefaultTemplate.Domain.Models.Enums;

public class ENotificationStatus : EnumModel
{
    public readonly static ENotificationStatus Created = new() { Id = "cr", Name = new Localizable("Created", "Созданный", "Созданный") };
    public readonly static ENotificationStatus Readed = new() { Id = "rd", Name = new Localizable("Readed", "Прочитан", "Прочитан") };

    public static ENotificationStatus[] All = { Created, Readed };
}

public class EProjectStatus : EnumModel
{
    public readonly static EProjectStatus Created = new() {Id = "cr", Name = new Localizable("Created", "Созданный", "Созданный")};
    public readonly static EProjectStatus Activated = new() {Id = "ac", Name = new Localizable("Activated", "Активированный", "Созданный"),};
    public readonly static EProjectStatus Completed = new() {Id = "cp", Name = new Localizable("Completed", "Завершённый", "Созданный")};

    public static EProjectStatus[] All = { Created, Activated, Completed };
}

public class EConstructionObjectStatus : EnumModel
{
    public readonly static EConstructionObjectStatus Created = new() { Id = "cr", Name = new Localizable("Created", "Созданный", "Созданный (кз)") };
    public readonly static EConstructionObjectStatus Active = new() { Id = "ac", Name = new Localizable("Active", "Активный", "Активный (кз)"), };
    public readonly static EConstructionObjectStatus Inactive = new() { Id = "iac", Name = new Localizable("Inactive", "Неактивный", "Неактивный (кз)") };

    public static EConstructionObjectStatus[] All = { Created, Active, Inactive };
}

public class EDevelopmentStage : EnumModel
{
    public static readonly EDevelopmentStage DesignStage = new() { Id = "design", Name = new Localizable("Design stage", "Проектная стадия", "") };
    public static readonly EDevelopmentStage PreDesignStage = new() { Id = "pre-design", Name = new Localizable("Pre design stage", "Предпроектная стадия", ""), };

    public static readonly EDevelopmentStage[] All = { DesignStage, PreDesignStage };
    
}

public class EDevelopmentStep : EnumModel
{
    public static readonly EDevelopmentStep EngineeringSurvey = new() { Id = "engineering", Name = new Localizable("Engineering survey", "Инженерные изыскания", "Injenerlik izdenister") };
    public static readonly EDevelopmentStep FeasibilityStydu = new() { Id = "feasibility", Name = new Localizable("Feasibility stydu", "Технико-экономическое обоснование", "Tehnıkalyq-ekonomıkalyq negizdeme") };

    public static readonly EDevelopmentStep[] All = { EngineeringSurvey, FeasibilityStydu };
}

public class EWorkStep : EnumModel
{
    public static readonly EWorkStep WorkGroup = new() { Id = "work-group", Name = new Localizable("Work group", "Состав рабочей группы", "Jumys tobynyń quramy") };
    public static readonly EWorkStep DesignPreparationOfDevelopment = new() { Id = "prepare-contract", Name = new Localizable("Preparation of the basis for the development of PD", "Подготовка основания для разработки ПД", "PD ázirleý úshin negizdeme daıyndaý") };
    public static readonly EWorkStep DevelopmentPD = new() { Id = "development-pd", Name = new Localizable("Development of PD", "Разработка ПД", "PD ázirleý") };
    public static readonly EWorkStep CompleteTab = new() { Id = "complete-tab", Name = new Localizable("Delivery of work results", "Сдача результатов работ", "Jumys nátıjelerin tapsyrý") };
    public static readonly EWorkStep PreparingBasicsForAI = new() { Id = "preparing-basics", Name = new Localizable("Preparing the basis for conducting AI", "Подготовка основания на проведение ИИ", "AI júrgizýge negizdeme daıyndaý") };
    public static readonly EWorkStep FormationOfReportingDoc = new() { Id = "formation-doc", Name = new Localizable("Generation of reporting documentation", "Формирование отчетной документации", "Eseptik qujattamany qalyptastyrý") };
    public static readonly EWorkStep PreparingDevelopmentFeasibility = new() { Id = "preparing-development", Name = new Localizable("Preparation of the basis for the feasibility study", "Подготовка основания разработки ТЭО", "TEN ázirleýdiń negizin daıyndaý") };
    public static readonly EWorkStep FeasibilityStudyDevelopment = new() { Id = "feasibility-development", Name = new Localizable("Feasibility study development", "Разработка ТЭО", "TEN ázіrleý") };
    public static readonly EWorkStep PreliminaryDesign = new() { Id = "preliminary-design", Name = new Localizable("Preliminary design", "Эскизный проект", "Nobaılyq joba") };
    public static readonly EWorkStep Kve = new() { Id = "kve", Name = new Localizable("KVE", "КВЭ", "KVE") };

    public static readonly EWorkStep[] All = { WorkGroup, DesignPreparationOfDevelopment, DevelopmentPD, CompleteTab, PreparingBasicsForAI, FormationOfReportingDoc, PreparingDevelopmentFeasibility, FeasibilityStudyDevelopment, PreliminaryDesign, Kve };
}

public class EDocumentVersionStatus : EnumModel
{
    public static readonly EDocumentVersionStatus Draft = new() {Id = "draft", Name = new Localizable("Draft", "Проект", "Joba") };
    public static readonly EDocumentVersionStatus InProgress = new() {Id = "inProgress", Name = new Localizable("In progress", "В работе", "Jumys") };
    public static readonly EDocumentVersionStatus Agreed = new() {Id = "agreed", Name = new Localizable("Agreed", "Согласован", "Kelisildi") };
    public static readonly EDocumentVersionStatus AgreeingProcess = new() {Id = "agreeingProcess", Name = new Localizable("Agreeing process", "На согласовании", "Kelisýde") };
    public static readonly EDocumentVersionStatus Approved = new() {Id = "approved", Name = new Localizable("Approved", "Утвержден", "Bekitildi") };
    public static readonly EDocumentVersionStatus Closed = new() {Id = "closed", Name = new Localizable("Closed", "Закрыт", "Jabyq") };

    public static readonly EDocumentVersionStatus[] All = {Draft, InProgress, Agreed, Approved, Closed, AgreeingProcess};
}

public class ERemarkStatus : EnumModel
{
    public static readonly ERemarkStatus Open = new() { Id = "open", Name = new Localizable("Open", "Открыто", "Открыто") };
    public static readonly ERemarkStatus InProgress = new() { Id = "inProgress", Name = new Localizable("In progress", "В работе", "В работе") };
    public static readonly ERemarkStatus Closed = new() { Id = "closed", Name = new Localizable("Closed", "Закрыто", "Закрыто") };

    public static ERemarkStatus[] All = { Open, InProgress, Closed };
}

public class ERemarkNameType : EnumModel
{
    public static readonly ERemarkNameType NameType = new() { Id = "namesOfNotes", Name = new Localizable("Names of notes", "Наименования замечания", "Наименования замечания") };
    public static readonly ERemarkNameType ContentType = new() { Id = "contentOfNotes", Name = new Localizable("Content of notes", "Содержания замечания", "Содержания замечания") };

    public static ERemarkNameType[] All = { NameType, ContentType };
}

public class EPackageDocumentStatus : EnumModel
{
    public static readonly EPackageDocumentStatus TestStatus = new() { Id = "test", Name = new Localizable("Test", "Тест", "Тест (кз)") };
}

public class EEntityType : EnumModel
{
    public static readonly EEntityType ApplicationForCve = new() { Id = "applicationForCve", Name = new Localizable("Application for cve", "Заявка на квэ", "Заявка на квэ") };
    public static readonly EEntityType SectionDocumentPackage = new() { Id = "sectionDocumentPackage", Name = new Localizable("Section of the document package", "Раздел пакета документов", "Раздел пакета документов") };
    public static readonly EEntityType ContractSurveys = new() { Id = "contractSurveys", Name = new Localizable("Contract for engineering surveys", "Договор на проведение инженерных изысканий", "Договор на проведение инженерных изысканий") };
    public static readonly EEntityType ContractDevelopmentFeasibility = new() { Id = "contractDevelopmentFeasibility", Name = new Localizable("Contract for the development of a feasibility study", "Договор на разработку ТЭО", "Договор на разработку ТЭО") };
    public static readonly EEntityType ContractDevelopmentPSD = new() { Id = "contractDevelopmentPSD", Name = new Localizable("Contract for the development of PSD", "Договор на разработку ПСД", "Договор на разработку ПСД") };
    public static readonly EEntityType AKPAct = new() { Id = "akpAct", Name = new Localizable("AKP Act", "Акт ПСР", "Акт ПСР") };
    public static readonly EEntityType AVRAct = new() { Id = "avrAct", Name = new Localizable("Act of AVR", "Акт АВР", "Акт АВР") };
    public static readonly EEntityType NotDigitizedDocument = new() { Id = "notDigitizedDocument", Name = new Localizable("Not a digitized document", "Не оцифрованный документ", "Не оцифрованный документ") };
    public static readonly EEntityType PackageDocuments = new() { Id = "packageDocuments", Name = new Localizable("Package of documents", "Пакет документов", "Пакет документов") };

    public static EEntityType[] All = { ApplicationForCve, SectionDocumentPackage, ContractSurveys, ContractDevelopmentFeasibility,
        ContractDevelopmentPSD, AKPAct, AVRAct, NotDigitizedDocument, PackageDocuments};
}

public class EDesignCalendarPlanTaskStatus : EnumModel
{
    public static readonly EDesignCalendarPlanTaskStatus Open = new() { Id = "open", Name = new Localizable("Open", "Открыто", "Ashyq") };
    public static readonly EDesignCalendarPlanTaskStatus InWork = new() { Id = "inWork", Name = new Localizable("In work", "В Работе", "Jumysta") };
    public static readonly EDesignCalendarPlanTaskStatus Close = new() { Id = "close", Name = new Localizable("Close", "Закрыто", "Jabyq") };
    public static readonly EDesignCalendarPlanTaskStatus Expired = new() { Id = "expired", Name = new Localizable("Expired", "Просрочено", "Merzіmі ótken") };

    public static EDesignCalendarPlanTaskStatus[] All = { Open, InWork, Close, Expired };
}

public class EContactDetailType : EnumModel
{
    public static readonly EContactDetailType Email = new() { Id = "email", Name = new Localizable("Email", "Почта", "Почта") };
    public static readonly EContactDetailType Phone = new() { Id = "phone", Name = new Localizable("Phone", "Телефон", "Телефон") };
    public static readonly EContactDetailType Skype = new() { Id = "skype", Name = new Localizable("Skype", "Скайп", "Скайп") };
    public static readonly EContactDetailType Telegram = new() { Id = "telegram", Name = new Localizable("Telegram", "Телеграм", "Телеграм") };
    public static EContactDetailType[] All = {Email, Phone, Skype, Telegram};
}

public class EActivityTypeEnum: EnumModel
{

    public static readonly EActivityTypeEnum Customer = new() { Id = "customer", Name = new Localizable("Customer", "Заказчик", "Заказчик") };
    public static readonly EActivityTypeEnum Exploration = new() { Id = "exploration", Name = new Localizable("Exploration activities", "Изыскательная деятельность", "Изыскательная деятельность") };
    public static readonly EActivityTypeEnum FS = new() { Id = "fs", Name = new Localizable("Feasibility study development", "Разработка ТЭО", "Разработка ТЭО") };
    public static readonly EActivityTypeEnum EE = new() { Id = "ee", Name = new Localizable("Economic expertise", "Экономическая экспертиза", "Экономическая экспертиза") };
    public static readonly EActivityTypeEnum CO = new() { Id = "co", Name = new Localizable("Coordinating agency", "Согласующий орган", "Согласующий орган") };
    public static readonly EActivityTypeEnum IS = new() { Id = "is", Name = new Localizable("Industry expertise", "Отраслевая экспертиза", "Отраслевая экспертиза") };
    public static readonly EActivityTypeEnum Author = new() { Id = "author", Name = new Localizable("Author", "Автор", "Автор") };
    public static readonly EActivityTypeEnum Signer = new() { Id = "signer", Name = new Localizable("Signer", "Подписант", "Подписант") };
    public static readonly EActivityTypeEnum Operator = new() { Id = "operator", Name = new Localizable("Operator", "Оператор", "Оператор") };

    public static EActivityTypeEnum[] All = { Customer, Exploration, FS, EE, CO, IS, Author, Signer, Operator }; 
}

public class EPermission : EnumModel
{
    public bool isGlobal { get; set; }
    public string? ParentId { get; set; }
    public EPermission? Parent { get; set; }
    public List<Guid>? RolesIds { get; set; }
    public List<Role>? Roles { get; set; }

    public static readonly EPermission CreateEnergyEfficiencyReference = new() { 
        Id = "createEnergyEfficiencyReference", 
        Name = new Localizable("Create", "Создать", "Создать") 
    };
    public static readonly EPermission DeleteEnergyEfficiencyReference = new()
    {
        Id = "deleteEnergyEfficiencyReference",
        Name = new Localizable("Delete", "Удалить", "Удалить")
    };
    public static readonly EPermission EditEnergyEfficiencyReference = new()
    {
        Id = "editEnergyEfficiencyReference",
        Name = new Localizable("Edit", "Изменить", "Изменить")
    };
    public static readonly EPermission ViewEnergyEfficiencyReference = new()
    {
        Id = "viewEnergyEfficiencyReference",
        Name = new Localizable("View", "Просмотр", "Просмотр")
    };
    public static readonly EPermission ViewReferenceList = new()
    {
        Id = "viewReferenceList",
        Name = new Localizable("View", "Просмотр", "Просмотр")
    };
    public static readonly EPermission Sign = new()
    {
        Id = "sign",
        Name = new Localizable("Sign", "Подписать", "Подписать")
    };
    public static EPermission[] All = { ViewReferenceList, CreateEnergyEfficiencyReference, DeleteEnergyEfficiencyReference, EditEnergyEfficiencyReference, 
        ViewEnergyEfficiencyReference, Sign };
}

public class EParticipantType : EnumModel
{
    public static readonly EParticipantType NaturalPerson = new() { Id = "naturalPerson", Name = new Localizable("Natural Person", "Физ лицо", "Физ лицо")};
    public static readonly EParticipantType Company = new() { Id = "company", Name = new Localizable("Company", "Юр лицо", "Юр лицо") };
    public static readonly EParticipantType IndividualEntrepreneur = new () { Id = "individual", Name = new Localizable("Individual Entrepreneur", "ИП", "ИП") };

    public static EParticipantType[] All = { NaturalPerson, Company, IndividualEntrepreneur };
}

public class EUnitType : EnumModel
{
    public static readonly EUnitType Department = new() { Id = "department", Name = new Localizable("Department", "Департамент", "Департамент") };
    public static readonly EUnitType Unit = new() { Id = "unit", Name = new Localizable("Unit", "Отдел", "Отдел") };
    public static readonly EUnitType Sector = new() { Id = "sector", Name = new Localizable("Sector", "Сектор", "Сектор") };

    public static EUnitType[] All = { Department, Unit, Sector };
}

public class ELocale : EnumModel
{
    public static readonly ELocale Ru = new() { Id = "ru", Name = new Localizable("Russian", "Русский", "Русский (кз)") };
    public static readonly ELocale En = new() { Id = "en", Name = new Localizable("English", "Английский", "Английский (кз)") };
    public static readonly ELocale Kk = new() { Id = "kk", Name = new Localizable("Kazakh", "Казахский", "Казахский (кз)") };

    public static ELocale[] All = { Ru, En, Kk };
}

public class EWorkgroupLinkedType : EnumModel
{
    public static readonly EWorkgroupLinkedType Document = new() { Id = "document", Name = new Localizable("Document", "Документ", "Документ (кз)") };
    public static readonly EWorkgroupLinkedType Section = new() { Id = "section", Name = new Localizable("Section", "Секция", "Секция (кз)") };

    public static EWorkgroupLinkedType[] All = { Document, Section };
}



public enum EModuleType
{
    Reference,
    Info
}