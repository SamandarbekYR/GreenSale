using GreenSale.Data.Entities;

namespace GreenSale.Producer.Data.Entities;

public class ProducerListing : Entity
{
    public Guid ProducerId { get; set; }
    public Producer? Producer { get; set; }
    public Guid DistrictId { get; set; }
    public Guid FeeId { get; set; }
    public ProducerListingFee? Fee { get; set; }
}