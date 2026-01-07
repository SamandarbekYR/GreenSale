using GreenSale.Broker.Data.Entities;
using GreenSale.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Et = GreenSale.Broker.Data.Entities;

namespace GreenSale.Broker.Data;

public class BrokerDbContext : DbContext
{
    public DbSet<Et.Broker> Brokers => Set<Et.Broker>();
    public DbSet<BrokerSubscription> BrokerSubscriptions => Set<BrokerSubscription>();

    public BrokerDbContext(DbContextOptions<BrokerDbContext> options) : base(options)
    { }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("broker");

        modelBuilder.Entity<BrokerSubscription>(e =>
        {
            e.HasOne(a => a.Broker)
             .WithMany(a => a.Subscriptions)
             .HasForeignKey(a => a.BrokerId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
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
