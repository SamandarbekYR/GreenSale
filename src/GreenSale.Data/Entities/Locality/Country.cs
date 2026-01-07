namespace GreenSale.Data.Entities.Locality;

public class Country : Entity<int>
{
    public virtual List<CountryLocale> Locales { get; set; } = new();
}