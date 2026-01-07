using GreenSale.Data.Entities;
using GreenSale.Data.Entities.Locality;

namespace GreenSale.Storage.Data.Entities;

public class Storage : Entity<Guid>, IActive, ICreated
{
    public long UserId { get; set; }
    public Guid DistrictId { get; set; }
    public string? Lattitude { get; set; }
    public string? Longitude { get; set; }
    public string? Address { get; set; } // ko'cha nomlari yoki arentrga bron joy
    public string? Image { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual List<StorageListing> StorageListings { get; set; } = new();
}