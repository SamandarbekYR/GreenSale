using GreenSale.Identity.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace GreenSale.Identity.Data.Seeds;

public static class SeedRoles
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<RoleGroup>(entity =>
        {
            entity.HasData(new List<RoleGroup>()
            {
                new RoleGroup
                {
                    Id = 1,
                    IsDeleted = false,
                    IsDefault = true
                }
            });
        });

        builder.Entity<Role>(entity =>
        {
            entity.HasData(new List<Role>()
            {
                new Role
                {
                    Id = DefaultRoles.AdminId,
                    Name = DefaultRoles.Admin,
                    NormalizedName = DefaultRoles.Admin,
                }
            });
        });
    }
}