using Identity.Application.Services.Email;
using Identity.Infrastructure.Common.Configuration.Models;
using Identity.Infrastructure.Services.Email;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Common.Configuration.Injections;

public static class ServicesInjection
{
    internal static IServiceCollection UseInfrastructureServices(
        this IServiceCollection services)
    {
        return services
            .UseEmailServices();
    }

    private static IServiceCollection UseEmailServices(
        this IServiceCollection services)
    {
        services
            .AddScoped<IEmailService, EmailService>()
            .AddScoped<IEmailMessageFactory, EmailMessageFactory>()
            .AddScoped<SmtpClientService>();
    }
}