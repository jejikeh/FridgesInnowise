using System.Reflection;
using Fridges.Application;
using Fridges.Application.Common;
using Fridges.Persistence;
using Fridges.Persistence.Common.Configuration;
using Fridges.ServiceHandler.Controllers;

namespace Fridges.ServiceHandler;

public static class FridgesInjectServiceHandler
{
    public static Assembly[] Controllers =
    {
        typeof(FridgeController).Assembly
    };
    
    public static WebApplicationBuilder UseService(WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile(
            $"appsettings.Fridges.{builder.Environment.EnvironmentName}.json", 
            false, 
            true);
        
        var fridgesServiceConfiguration = new FridgesServiceConfiguration(builder.Configuration);

        builder.Services
            .AddSingleton<IFridgesApplicationConfiguration>(fridgesServiceConfiguration)
            .AddSingleton<IFridgesPersistenceConfiguration>(fridgesServiceConfiguration);

        builder.Services
            .UseFridgesApplication()
            .UseFridgesPersistence(fridgesServiceConfiguration);
        
        return builder;
    }

    public static async Task<WebApplication> UseFridgesServiceExecuteAsync(this WebApplication app, Func<WebApplication, Task> next)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        
        try
        {
            var fridgesDbContext = serviceProvider.GetRequiredService<FridgesDbContext>();
            await fridgesDbContext.Database.EnsureCreatedAsync();
            
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