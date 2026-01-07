using GreenSale.Data.Entities;
using GreenSale.Storage.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Et = GreenSale.Storage.Data.Entities;
namespace GreenSale.Storage.Data;

public class StorageDbContext: DbContext
{
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
    { }

    public DbSet<Et.Storage> Storages => Set<Et.Storage>();
    public DbSet<StorageListing> StorageListings => Set<StorageListing>();
    public DbSet<StorageSubscription> StorageSubscriptions => Set<StorageSubscription>();
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
