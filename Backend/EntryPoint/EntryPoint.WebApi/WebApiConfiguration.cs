using EntryPoint.WebApi.Injections;
using Fridges.ServiceHandler;
using Identity.PresentationInjectionHelpers;
using InjectionAssemblyFromAsAnotherAssembly;

namespace EntryPoint.WebApi;

[InjectService(typeof(IdentityInjectServiceHandler))]
[InjectService(typeof(FridgesInjectServiceHandler))]
public static class WebApiConfiguration
{
    internal static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        var mvcBuilder = builder.Services
            .AddSwagger()
            .AddEndpointsApiExplorer()
            .AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = true; });

        builder.HandleInjectServiceAttribute(typeof(WebApiConfiguration), mvcBuilder);

        return builder;
    }

    internal static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.MapControllers();
        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

    internal static async Task<WebApplication> ExecuteAsync(this WebApplication app)
    {
        await app.UseIdentityServiceExecuteAsync(
            identityApplication => identityApplication.UseFridgesServiceExecuteAsync(
                fridgesApplication => fridgesApplication.RunAsync()));

        return app;
    }
}