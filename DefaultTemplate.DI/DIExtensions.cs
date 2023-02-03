using Microsoft.Extensions.DependencyInjection;
using DefaultTemplate.DataAccess;
using DefaultTemplate.DataAccess.Mapping;
using DefaultTemplate.DataAccess.Repositories;
using DefaultTemplate.DataAccess.Repositories.Users;
using DefaultTemplate.Domain.Models.AddressDetails;
using DefaultTemplate.Domain.Models.ContactDetails;
using DefaultTemplate.Domain.Models.Permissions;
using DefaultTemplate.Domain.Services.AddressDetails;
using DefaultTemplate.Domain.Services.Common;
using DefaultTemplate.Domain.Services.ContactDetails;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.Permissions;
using DefaultTemplate.Domain.Services.Roles;
using DefaultTemplate.Domain.Services.Users;
using DefaultTemplate.Domain.Services.Waiters;

namespace DefaultTemplate.DI
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDefaultServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AddressDetailsMapping).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IContextService, HttpContextService>();
            services.AddMemoryCache();

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
            
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IWaiterRepository, WaiterRepository>();
            services.AddScoped<IWaiterService, WaiterService>();
            #endregion

            return services;
        }
    }
}
