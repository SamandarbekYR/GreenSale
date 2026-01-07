using GreenSale.Data.Entities;

namespace GreenSale.Producer.Data.Entities;

public class Producer : Entity
{
    public long UserId { get; set; }
    public Guid DistrictId { get; set; }
    public virtual List<ProducerListing?> ProducerListings { get; set; } = new();
}