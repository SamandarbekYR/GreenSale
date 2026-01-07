using GreenSale.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenSale.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("GreenSaleDb"), options =>
            {
                options.MigrationsHistoryTable("migrations");
                options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            })
                .UseSnakeCaseNamingConvention();
        });
    }
}