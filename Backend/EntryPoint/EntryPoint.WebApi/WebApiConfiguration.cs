using EntryPoint.WebApi.Common.Configuration;
using EntryPoint.WebApi.Common.Configuration.Injections;
using Identity.Application;
using Identity.Application.Common.Configuration;
using Identity.Infrastructure;
using Identity.Infrastructure.Common.Configuration;
using Identity.Persistence;
using Identity.Persistence.Common.Configuration;

namespace EntryPoint.WebApi;

public static class WebApiConfiguration
{
    internal static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile(
            $"appsettings.Identity.{builder.Environment.EnvironmentName}.json", 
            false, 
            true);
        
        var identityLayerConfiguration = new IdentityLayerConfiguration(builder.Configuration);

        builder.Services
            .AddSingleton<IIdentityApplicationConfiguration>(identityLayerConfiguration)
            .AddSingleton<IIdentityPersistenceConfiguration>(identityLayerConfiguration)
            .AddSingleton<IIdentityInfrastructureConfiguration>(identityLayerConfiguration);
        
        builder.Services
            .UseIdentityApplication()
            .UseIdentityPersistence(identityLayerConfiguration)
            .UseIdentityInfrastructure();

        builder.Services
            .AddSwagger()
            .AddEndpointsApiExplorer()
            .AddControllers();

        return builder;
    }

    internal static WebApplication Configure(this WebApplication app)
    {
        app.MapControllers();
        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }

    internal static async Task<WebApplication> ExecuteAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        
        try
        {
            var identityDbContext = serviceProvider.GetRequiredService<IdentityDbContext>();
            await identityDbContext.Database.EnsureCreatedAsync();
            
            await app.RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR:" + ex.Message);
            
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Host terminated unexpectedly");
        }

        return app;
    }
}