using Fridges.Application.Services;
using Fridges.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fridges.Persistence.Common.Configuration.Injections;

internal static class ServicesInjection
{
    internal static IServiceCollection UsePersistenceServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IFridgeModelsRepository, FridgeModelRepository>()
            .AddScoped<IManufactureRepository, ManufactureRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IFridgeRepository, FridgeRepository>()
            .AddScoped<IFridgeProductRepository, FridgeProductRepository>();
    }
}