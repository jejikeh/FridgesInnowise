using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application;

public static class IdentityApplicationInjection
{
    public static IServiceCollection UseIdentityApplication(this IServiceCollection services)
    {
        return services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(IdentityApplicationInjection).Assembly));
    }
}