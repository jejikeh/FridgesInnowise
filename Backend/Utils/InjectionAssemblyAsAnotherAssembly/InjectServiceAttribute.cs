using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InjectionAssemblyFromAsAnotherAssembly;

[AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
public class InjectServiceAttribute(Type loadAssemblyServiceType) : Attribute
{
    private Assembly LoadAssemblyService { get; } = loadAssemblyServiceType.Assembly;
    
    public WebApplicationBuilder UseService(WebApplicationBuilder webApplicationBuilder, IMvcBuilder builder)
    {
        var injectHandlerType = LoadAssemblyService.GetExportedTypes().FirstOrDefault(type => type.GetMethod("UseService") != null);
        if (injectHandlerType is null)
        {
            throw new NullReferenceException($"UseService from {LoadAssemblyService} has not been injected. There is no UseService method");
        }
        
        var controllers = (Assembly[]?)injectHandlerType.GetField("Controllers")?.GetValue(null);
        if (controllers is null)
        {
            throw new NullReferenceException($"Controllers from {LoadAssemblyService} has not been injected. There is no Controllers field");
        }

        foreach (var controller in controllers)
        {
            Console.WriteLine($"Controllers from {LoadAssemblyService} has been injected: {controller.GetType().Assembly}");
            
            builder
                .AddApplicationPart(controller.GetType().Assembly);
        }
        
        var useServices = injectHandlerType.GetMethod("UseService");
        if (useServices is null)
        {
            throw new NullReferenceException($"UseService from {LoadAssemblyService} has not been injected. There is no UseService method");
        }
        
        var returnedBuilder = (WebApplicationBuilder?)useServices.Invoke(null, new object[] {webApplicationBuilder});
        if (returnedBuilder is null)
        {
            throw new NullReferenceException($"UseService from {LoadAssemblyService} has not been injected. The returned builder is null");
        }
        
        return returnedBuilder;
    }
}