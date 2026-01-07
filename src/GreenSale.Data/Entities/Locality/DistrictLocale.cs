namespace GreenSale.Data.Entities.Locality;

public class DistrictLocale : EntityLocale
{
    public long DistrictId { get; set; }
    public District? District { get; set; }
    public required string DistrictName { get; set; }
}