using GreenSale.Data.Entities;

namespace GreenSale.Broker.Data.Entities;

public class BrokerSubscription : Entity, IActive
{
    public Guid SubscriptionId { get; set; }
    public Guid BrokerId { get; set; }
    public Broker? Broker { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}