using GreenSale.Data.Entities;

namespace GreenSale.Storage.Data.Entities;

public class StorageSubscription : Entity, IActive
{
    public Guid SubscriptionId { get; set; }
    public Guid StorageId { get; set; }
    public Storage? Storage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
}