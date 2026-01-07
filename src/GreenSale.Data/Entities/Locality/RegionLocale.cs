namespace GreenSale.Data.Entities.Locality;

public class RegionLocale : EntityLocale
{
    public long RegionId { get; set; }
    public Region? Region { get; set; }
    public required string Name { get; set; } 
}