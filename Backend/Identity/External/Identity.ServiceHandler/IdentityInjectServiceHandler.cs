using System.Reflection;
using Identity.Application;
using Identity.Application.Common.Configuration;
using Identity.Infrastructure;
using Identity.Infrastructure.Common.Configuration;
using Identity.Persistence;
using Identity.Persistence.Common.Configuration;
using Identity.PresentationInjectionHelpers.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.PresentationInjectionHelpers;

public static class IdentityInjectServiceHandler
{
    public static Assembly[] Controllers =
    {
        typeof(UserController).Assembly
    };
    
    public static WebApplicationBuilder UseService(WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile(
            $"appsettings.Identity.{builder.Environment.EnvironmentName}.json", 
            false, 
            true);
        
        var identityLayerConfiguration = new IdentityServiceConfiguration(builder.Configuration);

        builder.Services
            .AddSingleton<IIdentityApplicationConfiguration>(identityLayerConfiguration)
            .AddSingleton<IIdentityPersistenceConfiguration>(identityLayerConfiguration)
            .AddSingleton<IIdentityInfrastructureConfiguration>(identityLayerConfiguration);
        
        builder.Services
            .UseIdentityApplication()
            .UseIdentityPersistence(identityLayerConfiguration)
            .UseIdentityInfrastructure(identityLayerConfiguration);
        
        return builder;
    }

    public static async Task<WebApplication> UseIdentityServiceExecuteAsync(this WebApplication app, Func<WebApplication, Task> next)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        
        try
        {
            var identityDbContext = serviceProvider.GetRequiredService<IdentityDbContext>();
            await identityDbContext.Database.EnsureCreatedAsync();
            
            await next(app);
        }
        catch (Exception ex)
        {
            // NOTE(jejikeh): We cant use ServiceProvider here
            // NOTE(jejikeh): Maybe here we also can use delegate?
            // TODO(jejikeh): Get here ILogger somehow 
            Console.WriteLine("ERROR:" + ex.Message);
            Console.WriteLine("Host terminated unexpectedly");
        }

        return app;
    }
}