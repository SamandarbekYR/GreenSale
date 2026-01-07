using GreenSale.Identity.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace GreenSale.Identity.Data.Seeds;

public static class SeedPermissions
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<PermissionGroup>(entity =>
        {
            entity.HasData(new List<PermissionGroup>()
            {
                new()
                {
                    Id = 1,
                    IsDeleted = false,
                    Name = nameof(PermissionGroups.Admin)
                }
            });
        });
    }
}