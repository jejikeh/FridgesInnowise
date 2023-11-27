using Identity.Application.Services;
using Identity.Application.Services.Email;
using Identity.Domain;
using Identity.Persistence.Common.Configuration.Models;
using Identity.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence.Common.Configuration.Injections;

internal static class ServicesInjection
{
    internal static IServiceCollection UsePersistenceServices(this IServiceCollection services, IdentityConfiguration configuration)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IAuthorizeTokenService, AuthorizeTokenService>()
            .UseIdentityServices(configuration);
    }

    private static IServiceCollection UseIdentityServices(this IServiceCollection services, IdentityConfiguration configuration)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.User = configuration.Options.User;
            options.Password = configuration.Options.Password;
            options.SignIn = configuration.Options.SignIn;
        })
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<Role>();

        return services;
    }
}