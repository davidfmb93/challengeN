using ChallengeN.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN.Infrastructure.Contexts;
public class CNDbContext : DbContext
{
    public CNDbContext(DbContextOptions<CNDbContext> options) : base(options) { }

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var entityEmployeeBuilder = modelBuilder.Entity<Employee>();
        entityEmployeeBuilder.Property(r => r.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

        var entityRoleBuilder = modelBuilder.Entity<Role>();
        entityEmployeeBuilder.Property(r => r.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

        var entityRolePermissionBuilder = modelBuilder.Entity<Role>();
        entityEmployeeBuilder.Property(r => r.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<Role>()
            .HasMany(r => r.RolePermissions)
            .WithOne(rp => rp.Role)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<Permission>()
            .HasMany(p => p.RolePermissions)
            .WithOne(rp => rp.Permission)
            .HasForeignKey(rp => rp.PermissionId);

        base.OnModelCreating(modelBuilder);

    }
}
