using Microsoft.EntityFrameworkCore;
using DefaultTemplate.DataAccess.Config;

namespace DefaultTemplate.DataAccess;

public class DefaultContext : DbContext
{

    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<PermissionEntity> Permisions { get; set; } = null!;


    public DefaultContext(DbContextOptions<DefaultContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new ProjectStatusEntityConfig());

    }
}