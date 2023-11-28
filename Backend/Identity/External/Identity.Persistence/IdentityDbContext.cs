using System.Reflection;
using Identity.Application.Common.Models.Tokens;
using Identity.Domain;
using Identity.Persistence.Common.Configuration;
using Identity.Persistence.Common.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options, IIdentityPersistenceConfiguration configuration)
    : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.ApplyConfiguration(new SeedAdminUserConfiguration(configuration));
    }
}