using Microsoft.Extensions.DependencyInjection;
using DefaultTemplate.DataAccess;
using DefaultTemplate.DataAccess.Mapping;
using DefaultTemplate.DataAccess.Repositories;
using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Models.ContactDetails;
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Services.AddressDetails;
using DefaultTemplate.Domain.Services.Common;
using DefaultTemplate.Domain.Services.ContactDetails;
using DefaultTemplate.Domain.Services.System;

namespace DefaultTemplate.DI
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDefaultServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AddressDetailsMapping).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IContextService, HttpContextService>();
            
            #region Enums

            services.AddScoped<IEnumRepository<EPermission>, PermissionRepository>();
            services.AddScoped<IEnumService<EPermission>, EnumService<EPermission>>();
            #endregion

            #region Entities

            services.AddScoped<IAddressDetailRepository, AddressDetailRepository>();
            services.AddScoped<ICrudRepository<AddressDetail, AddressDetailQuery>, AddressDetailRepository>();
            services.AddScoped<IAddressDetailService, AddressDetailService>();

            
            services.AddScoped<IContactDetailRepository, ContactDetailRepository>();
            services.AddScoped<ICrudRepository<ContactDetail, ContactDetailQuery>, ContactDetailRepository>();
            services.AddScoped<IContactDetailService, ContactDetailService>();

            #endregion

            return services;
        }
    }
}
