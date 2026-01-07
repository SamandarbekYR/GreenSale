namespace GreenSale.Data.Entities.Locality;

public class CountryLocale : EntityLocale
{
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public required string Name { get; set; } 
}


