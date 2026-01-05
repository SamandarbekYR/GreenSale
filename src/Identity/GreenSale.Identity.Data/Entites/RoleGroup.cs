using GreenSale.Data.Entities;

namespace GreenSale.Identity.Data.Entites;

public class RoleGroup : Entity<long>
{
    public bool IsDefault { get; set; }
    public Guid? OrganizationId { get; set; }

    public ICollection<Role>? Roles { get; set; }
}