using GreenSale.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GreenSale.Identity.Data.Entites;

public class User : IdentityUser<long>,IEntity
{
    public string? FirstName { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Device>? Devices { get; set; }
}