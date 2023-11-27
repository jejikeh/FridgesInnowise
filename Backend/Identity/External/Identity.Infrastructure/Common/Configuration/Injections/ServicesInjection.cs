using Identity.Application.Services.Email;
using Identity.Infrastructure.Common.Configuration.Models;
using Identity.Infrastructure.Services;
using Identity.Infrastructure.Services.Email;
using Identity.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Common.Configuration.Injections;

public static class ServicesInjection
{
    internal static IServiceCollection UseInfrastructureServices(
        this IServiceCollection services)
    {
        return services
            .UseEmailServices()
            .AddSingleton<IRandomAccessTokenProvider, JwtTokenProvider>();
    }

    private static IServiceCollection UseEmailServices(
        this IServiceCollection services)
    {
        return services
            .AddScoped<IEmailService, EmailService>()
            .AddScoped<IEmailMessageFactory, EmailMessageFactory>()
            .AddSingleton<SmtpClientService>();
    }
}