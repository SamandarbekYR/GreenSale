using GreenSale.Data.Entities;

namespace GreenSale.Broker.Data.Entities;

public class Broker : Entity
{
    public long UserId { get; set; }
    public virtual List<BrokerSubscription> Subscriptions { get; set; } = new List<BrokerSubscription>();
}