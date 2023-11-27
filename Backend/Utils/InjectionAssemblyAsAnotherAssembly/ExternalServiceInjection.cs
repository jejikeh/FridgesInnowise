using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InjectionAssemblyFromAsAnotherAssembly;

public static class ExternalServiceInjection
{
    public static WebApplicationBuilder HandleInjectServiceAttribute(
        this WebApplicationBuilder webApplicationBuilder, 
        Type configurationType,
        IMvcBuilder mvcBuilder)
    {
        var attributes = System.Attribute.GetCustomAttributes(configurationType);
        foreach (var attribute in attributes)
        {
            if (attribute is InjectServiceAttribute injectServiceAttribute)
            {
                injectServiceAttribute.UseService(webApplicationBuilder, mvcBuilder);
            }
        }
        
        return webApplicationBuilder;
    }
}