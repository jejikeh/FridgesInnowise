using System.Reflection;
using Fridges.Application.PipelineBehaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Fridges.Application;

public static class FridgesApplicationInjection
{
    public static IServiceCollection UseFridgesApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        serviceCollection.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        return serviceCollection;
    }
}