namespace EntryPoint.WebApi.Common.Configuration.Injections;

public static class SwaggerInjection
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return services.AddSwaggerGen();
    }
}