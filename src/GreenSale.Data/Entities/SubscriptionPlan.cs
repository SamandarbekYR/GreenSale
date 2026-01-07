namespace GreenSale.Data.Entities;

public class SubscriptionPlan : Entity<Guid>, ICreated, IActive
{
    public long Price { get; set; }
    public int DurationDays { get; set; }
    public SubscriptionType Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
public enum SubscriptionType
{
    Broker,
    Storage,
}