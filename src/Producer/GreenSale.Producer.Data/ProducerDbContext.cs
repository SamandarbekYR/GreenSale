using GreenSale.Data.Entities;
using GreenSale.Producer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Et = GreenSale.Producer.Data.Entities;
namespace GreenSale.Producer.Data;

public class ProducerDbContext : DbContext
{
    public ProducerDbContext(DbContextOptions<ProducerDbContext> options) : base(options)
    { }

    public DbSet<Et.Producer> Producers => Set<Et.Producer>();
    public DbSet<ProducerListing> ProducerListings => Set<ProducerListing>();
    public DbSet<ProducerListingFee> ProducerListingFees => Set<ProducerListingFee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("producer");
        modelBuilder.Entity<ProducerListing>(e =>
        {
            e.HasOne(a => a.Producer)
             .WithMany(a => a.ProducerListings)
             .HasForeignKey(a => a.ProducerId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(a => a.Fee)
                .WithMany(a => a.ProducerListings)
                .HasForeignKey(a => a.FeeId)
                .OnDelete(DeleteBehavior.Restrict);
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