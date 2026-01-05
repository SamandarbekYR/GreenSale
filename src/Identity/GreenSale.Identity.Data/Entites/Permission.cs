using GreenSale.Data.Entities;

namespace GreenSale.Identity.Data.Entites;

public class Permission : Entity<long>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public long GroupId { get; set; }
    public PermissionGroup? Group { get; set; }

    public ICollection<RolePermission>? RolePermissions { get; set; }
}
