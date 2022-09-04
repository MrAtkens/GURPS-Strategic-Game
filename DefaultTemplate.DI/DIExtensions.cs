using Microsoft.Extensions.DependencyInjection;
using DefaultTemplate.DataAccess;
using DefaultTemplate.DataAccess.Repositories.Enums;
using DefaultTemplate.Domain.Services.Common;
using DefaultTemplate.Domain.Services.System;

namespace DefaultTemplate.DI
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDefaultServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BankProfile).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IContextService, HttpContextService>();

            #region References
            services.AddScoped<IDesignCalendarPlanTaskNameRepository, DesignCalendarPlanTaskNameRepository>();
            services.AddScoped<ICrudRepository<DesignCalendarPlanTaskName, DesignCalendarPlanTaskNameQuery>, DesignCalendarPlanTaskNameRepository>();
            services.AddScoped<IDesignCalendarPlanTaskNameService, DesignCalendarPlanTaskNameService>();

            #endregion

            #region Enums

            services.AddScoped<IEnumRepository<EProjectStatus>, ProjectStatusRepository>();
            services.AddScoped<IEnumService<EProjectStatus>, EnumService<EProjectStatus>>();
            #endregion

            #region Entities

            services.AddScoped<IConstructionObjectCategoryRepository, ConstructionObjectCategoryRepository>();
            services.AddScoped<ICrudRepository<ConstructionObjectCategory, ConstructionObjectCategoryQuery>, ConstructionObjectCategoryRepository>();
            services.AddScoped<IConstructionObjectCategoryService, ConstructionObjectCategoryService>();

            #endregion


            services.AddScoped<INotificationTypeRepository, NotificationTypeRepository>();
            services.AddScoped<INotificationTypeService, NotificationTypeService>();


            return services;
        }
    }
}
