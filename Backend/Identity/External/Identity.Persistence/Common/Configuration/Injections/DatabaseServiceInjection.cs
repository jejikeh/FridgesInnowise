using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence.Common.Configuration.Injections;

internal static class DatabaseServiceInjection
{
    internal static IServiceCollection UseSqliteProvider(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlite(
                connectionString, 
                builder => builder.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName));
        });
    }

    internal static IServiceCollection UsePostgresqlProvider(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString, 
                builder => builder.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName));
        });
    }     
}