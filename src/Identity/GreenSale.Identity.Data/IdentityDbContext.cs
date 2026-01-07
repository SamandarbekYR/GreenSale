using GreenSale.Data.Entities;
using GreenSale.Identity.Data.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GreenSale.Identity.Data;

public partial class IdentityDbContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public DbSet<Device> Devices => Set<Device>();
    public DbSet<UserOtp> UserOtps => Set<UserOtp>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<PermissionGroup> PermissionGroups => Set<PermissionGroup>();
    public DbSet<RoleGroup> RoleGroups => Set<RoleGroup>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("identity");

        base.OnModelCreating(builder);

        builder.Entity<Role>().ToTable("roles");
        builder.Entity<RoleClaim>().ToTable("role_claims");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<User>().ToTable("users");
        builder.Entity<UserLogin>().ToTable("user_logins");
        builder.Entity<UserClaim>().ToTable("user_claims");
        builder.Entity<UserToken>().ToTable("user_tokens");

        builder.Entity<Permission>(entity =>
        {
            entity.HasIndex(e => e.Name)
                .IsUnique(false);
        });

        builder.Entity<RolePermission>(entity =>
        {
            entity.Navigation(e => e.Permission)
                .AutoInclude();

            entity.HasKey(e => new { e.RoleId, e.PermissionId });
        });

        builder.Entity<Role>(entity =>
        {
            entity.HasIndex(x => x.Name)
                .IsUnique();

            entity.Navigation(e => e.RolePermissions)
                .AutoInclude();
        });

        builder.Entity<PermissionGroup>(entity =>
        {
            entity.HasMany(e => e.Permissions)
                .WithOne(e => e.Group);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });
        builder.Entity<Device>(entity =>
        {
            entity.HasKey(d => d.Id);

            entity.HasOne(d => d.User)
                .WithMany(u => u.Devices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(d => d.DeviceId)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(d => d.DisplayName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(d => d.IPAddress)
                .HasMaxLength(45);

            entity.Property(d => d.IsTrusted)
                .HasDefaultValue(false);

            entity.Property(d => d.FireBaseToken)
                .HasMaxLength(255);
        });
        builder.Entity<Permission>(entity =>
        {
            entity.HasIndex(e => e.Name)
                .IsUnique(false);
        });

        builder.Entity<RolePermission>(entity =>
        {
            entity.Navigation(e => e.Permission)
                .AutoInclude();

            entity.HasKey(e => new { e.RoleId, e.PermissionId });
        });

        builder.Entity<Role>(entity =>
        {
            entity.HasIndex(x => x.Name)
                .IsUnique();

            entity.Navigation(e => e.RolePermissions)
                .AutoInclude();
        });

        builder.Entity<PermissionGroup>(entity =>
        {
            entity.HasMany(e => e.Permissions)
                .WithOne(e => e.Group);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is ICreated created)
            {
                if (entry.State == EntityState.Added)
                    created.CreatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
