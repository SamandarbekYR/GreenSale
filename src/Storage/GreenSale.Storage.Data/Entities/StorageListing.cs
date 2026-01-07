using GreenSale.Data.Entities;
using GreenSale.Data.Entities.Enums;

namespace GreenSale.Storage.Data.Entities;

public class StorageListing : Entity, IActive
{
    public Guid StorageId { get; set; }
    public Storage? Storage { get; set; }
    public required string ProductName { get; set; }
    public required long Price { get; set; }
    public decimal Amount { get; set; }
    public UnitOf Unit { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }
}