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
            .UsePersistenceServices(identityPersistenceConfiguration.IdentityConfiguration);
    }
}