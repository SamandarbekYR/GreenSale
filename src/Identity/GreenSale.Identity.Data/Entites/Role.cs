using Microsoft.AspNetCore.Identity;

namespace GreenSale.Identity.Data.Entites;

public class Role : IdentityRole<long>
{
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public long? GroupId { get; set; }
    public RoleGroup? Group { get; set; }
}
