using Microsoft.EntityFrameworkCore;
using DefaultTemplate.DataAccess.Config;
using DefaultTemplate.DataAccess.Config.UserProfileConfigs;
using DefaultTemplate.DataAccess.Entities.Users;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess;

public class DefaultContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<PermissionEntity> Permisions { get; set; } = null!;
    public DbSet<RolePermissionEntity> RolesPermissions { get; set; } = null!;
    public DbSet<AddressDetailEntity> AddressDetails { get; set; } = null!;
    public DbSet<ContactDetailEntity> ContactDetails { get; set; } = null!;
    public DbSet<EmployeeEntity> Employees { get; set; } = null!;
    public DbSet<WaiterEntity> Waiters { get; set; } = null!;
    public DbSet<BussinessEntity> Bussinesses { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new RoleConfig());
        modelBuilder.ApplyConfiguration(new PermissionConfig());
        modelBuilder.ApplyConfiguration(new AddressDetailConfig());

    }
}