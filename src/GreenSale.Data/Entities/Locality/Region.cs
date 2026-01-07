namespace GreenSale.Data.Entities.Locality;

public class Region : Entity<long>
{
    public virtual List<RegionLocale> Locales { get; set; } = new();
}