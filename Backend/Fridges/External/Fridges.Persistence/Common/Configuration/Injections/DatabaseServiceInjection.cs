using Fridges.Persistence.Common.Configuration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fridges.Persistence.Common.Configuration.Injections;

internal static class DatabaseServiceInjection
{
    internal static IServiceCollection UseDbProvider(this IServiceCollection services, DatabaseConfiguration databaseConfiguration)
    {
        return databaseConfiguration.DbProvider switch
        {
            SupportedDbProvider.Sqlite => services.UseSqliteProvider(databaseConfiguration.ConnectionString),
            SupportedDbProvider.Postgresql => services.UsePostgresqlProvider(databaseConfiguration.ConnectionString),
            _ => throw new ArgumentOutOfRangeException(nameof(databaseConfiguration.DbProvider), databaseConfiguration.DbProvider, null)
        };
    }

    private static IServiceCollection UseSqliteProvider(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<FridgesDbContext>(options =>
        {
            options.UseSqlite(
                connectionString, 
                builder => builder.MigrationsAssembly(typeof(FridgesDbContext).Assembly.FullName));
        });
    }

    private static IServiceCollection UsePostgresqlProvider(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<FridgesDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString, 
                builder => builder.MigrationsAssembly(typeof(FridgesDbContext).Assembly.FullName));
        });
    }     
}