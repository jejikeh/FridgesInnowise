using Fridges.Persistence.Common.Configuration;
using Fridges.Persistence.Common.Configuration.Injections;
using Fridges.Persistence.Common.Configuration.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Fridges.Persistence;

public static class FridgesPersistenceInjection
{
    public static IServiceCollection UseFridgesPersistence(this IServiceCollection services, IFridgesPersistenceConfiguration fridgesPersistenceConfiguration)
    {
        return services
            .UseDbProvider(fridgesPersistenceConfiguration.DatabaseConfiguration)
            .UsePersistenceServices();
    }
}