using Identity.Persistence.Common.Configuration;
using Identity.Persistence.Common.Configuration.Injections;
using Identity.Persistence.Common.Configuration.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence;

public static class IdentityPersistenceInjection
{
    public static IServiceCollection UseIdentityPersistence(this IServiceCollection services, IIdentityPersistenceConfiguration identityPersistenceConfiguration)
    {
        return services
            .UseDbProvider(identityPersistenceConfiguration.DatabaseConfiguration)
            .UsePersistenceServices()
            .UseIdentityServices(identityPersistenceConfiguration.IdentityConfiguration);
    }

    private static IServiceCollection UseDbProvider(this IServiceCollection services, DatabaseConfiguration databaseConfiguration)
    {
        return databaseConfiguration.DbProvider switch
        {
            SupportedDbProvider.Sqlite => services.UseSqliteProvider(databaseConfiguration.ConnectionString),
            SupportedDbProvider.Postgresql => services.UsePostgresqlProvider(databaseConfiguration.ConnectionString),
            _ => throw new ArgumentOutOfRangeException(nameof(databaseConfiguration.DbProvider), databaseConfiguration.DbProvider, null)
        };
    }
}