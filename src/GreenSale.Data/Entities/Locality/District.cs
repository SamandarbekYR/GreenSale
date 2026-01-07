namespace GreenSale.Data.Entities.Locality;

public class District : Entity<long>
{
    public virtual List<DistrictLocale> Locales { get; set; } = new();
}