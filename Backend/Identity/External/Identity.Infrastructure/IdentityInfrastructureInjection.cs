using Identity.Infrastructure.Common.Configuration.Injections;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class IdentityInfrastructureInjection
{
    public static IServiceCollection UseIdentityInfrastructure(this IServiceCollection services)
    {
        return services
            .UseInfrastructureServices();
    }
}