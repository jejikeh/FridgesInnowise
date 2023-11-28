using Identity.Application.Common.Configuration;
using Identity.Application.Common.Configuration.Models;
using Identity.Infrastructure.Common.Configuration;
using Identity.Infrastructure.Common.Configuration.Models;
using Identity.Persistence.Common.Configuration;
using Identity.Persistence.Common.Configuration.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Identity.PresentationInjectionHelpers;

public class IdentityServiceConfiguration(IConfiguration configuration) :
    IIdentityApplicationConfiguration,
    IIdentityPersistenceConfiguration,
    IIdentityInfrastructureConfiguration
{
    public IdentityFeaturesConfiguration IdentityFeatures { get; } = new IdentityFeaturesConfiguration
    {
        SendEmailConfirmation = bool.Parse(configuration["Identity:Features:SendEmailConfirmation"] ?? "true"),
    };

    public DatabaseConfiguration DatabaseConfiguration { get; } = new DatabaseConfiguration
    {
        ConnectionString = configuration["Identity:Database:ConnectionString"] ?? throw new Exception("Identity:Database:ConnectionString is not set"),
        DbProvider = Enum.Parse<SupportedDbProvider>(configuration["Identity:Database:DbProvider"] ?? "Sqlite", true),
    };

    public IdentityConfiguration IdentityConfiguration { get; } = new IdentityConfiguration
    {
        Options = new IdentityOptions
        {
            User = new UserOptions
            {
                AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
                RequireUniqueEmail = bool.Parse(configuration["Identity:Authentication:User:RequireUniqueEmail"] ?? "true")
            },
            Password = new PasswordOptions
            {
                RequiredLength = int.Parse(configuration["Identity:Authentication:Password:RequiredLength"] ?? "0"),
                RequiredUniqueChars = int.Parse(configuration["Identity:Authentication:Password:RequiredUniqueChars"] ?? "0"),
                RequireNonAlphanumeric = bool.Parse(configuration["Identity:Authentication:Password:RequireNonAlphanumeric"] ?? "false"),
                RequireLowercase = bool.Parse(configuration["Identity:Authentication:Password:RequireLowercase"] ?? "false"),
                RequireUppercase = bool.Parse(configuration["Identity:Authentication:Password:RequireUppercase"] ?? "false"),
                RequireDigit = bool.Parse(configuration["Identity:Authentication:Password:RequireDigit"] ?? "false")
            },
            SignIn = new SignInOptions
            {
                RequireConfirmedEmail = bool.Parse(configuration["Identity:Authentication:SignIn:RequireConfirmedEmail"] ?? "false"),
                RequireConfirmedPhoneNumber = bool.Parse(configuration["Identity:Authentication:SignIn:RequireConfirmedPhoneNumber"] ?? "false"),
                RequireConfirmedAccount = bool.Parse(configuration["Identity:Authentication:SignIn:RequireConfirmedAccount"] ?? "false")
            }
        }
    };

    public RefreshTokenConfiguration RefreshTokenConfiguration { get; } = new RefreshTokenConfiguration
    {
        RefreshTokenValidityInSeconds = int.Parse(configuration["Identity:RefreshToken:RefreshTokenValidityInSeconds"] ?? "30")
    };

    public SeedDataConfiguration SeedDataConfiguration { get; } = new SeedDataConfiguration
    {
        Seed = bool.Parse(configuration["Identity:SeedData:Seed"] ?? "false"),
        AdminId = Guid.Parse(configuration["Identity:SeedData:AdminId"] ?? throw new Exception("Identity:SeedData:AdminId is not set")),
        AdminPassword = configuration["Identity:SeedData:AdminPassword"] ?? throw new Exception("Identity:SeedData:AdminPassword is not set"),
        AdminEmail = configuration["Identity:SeedData:AdminEmail"] ?? throw new Exception("Identity:SeedData:AdminEmail is not set"),
        AdminUserName = configuration["Identity:SeedData:AdminUsername"] ?? throw new Exception("Identity:SeedData:AdminUsername is not set"),
    };

    public JwtTokenConfiguration JwtTokenConfiguration { get; } = new JwtTokenConfiguration
    {
        Issuer = configuration["Identity:JwtToken:Issuer"] ?? throw new Exception("Identity:JwtToken:Issuer is not set"),
        Audience = configuration["Identity:JwtToken:Audience"] ?? throw new Exception("Identity:JwtToken:Audience is not set"),
        Secret = configuration["Identity:JwtToken:Secret"] ?? throw new Exception("Identity:JwtToken:Secret is not set"),
        ExpirationInSeconds = int.Parse(configuration["Identity:JwtToken:ExpirationInSeconds"] ?? "3600")
    };

    public EmailConfiguration EmailConfiguration { get; } = new EmailConfiguration
    {
        Host = configuration["Identity:Email:Host"] ?? "Smtp",
        Port = int.Parse(configuration["Identity:Email:Port"] ?? "587"),
        Username = configuration["Identity:Email:Username"] ?? throw new Exception("Identity:Email:Username is not set"),
        Password = configuration["Identity:Email:Password"] ?? throw new Exception("Identity:Email:Password is not set"),
        From = configuration["Identity:Email:From"] ?? throw new Exception("Identity:Email:From is not set")
    };
    
    public string Host { get; } = configuration[WebHostDefaults.ServerUrlsKey] ?? throw new InvalidOperationException();
}