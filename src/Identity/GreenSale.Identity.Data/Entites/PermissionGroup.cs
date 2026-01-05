using GreenSale.Data.Entities;

namespace GreenSale.Identity.Data.Entites;

public class PermissionGroup : Entity<long>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Permission>? Permissions { get; set; }
}