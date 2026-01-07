using GreenSale.Data.Entities;

namespace GreenSale.Producer.Data.Entities;

public class ProducerListingFee : Entity,IActive
{
    public long Price { get; set; }
    public int DurationDate { get; set; }
    public bool IsActive { get; set; }
    public virtual List<ProducerListing>? ProducerListings { get; set; }
}