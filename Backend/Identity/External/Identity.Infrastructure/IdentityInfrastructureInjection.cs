using Identity.Infrastructure.Common.Configuration;
using Identity.Infrastructure.Common.Configuration.Injections;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class IdentityInfrastructureInjection
{
    public static IServiceCollection UseIdentityInfrastructure(
        this IServiceCollection services,
        IIdentityInfrastructureConfiguration identityInfrastructureConfiguration)
    {
        return services.UseInfrastructureServices(identityInfrastructureConfiguration);
    }
}