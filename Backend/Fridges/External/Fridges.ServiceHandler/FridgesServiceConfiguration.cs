using Fridges.Application.Common;
using Fridges.Persistence.Common.Configuration;
using Fridges.Persistence.Common.Configuration.Models;
using Microsoft.AspNetCore.Identity;

namespace Fridges.ServiceHandler;

public class FridgesServiceConfiguration(IConfiguration configuration) :
    IFridgesApplicationConfiguration,
    IFridgesPersistenceConfiguration
{
    public int PageSize { get; } = int.Parse(configuration["Fridges:PageSize"] ?? "10");
    
    public DatabaseConfiguration DatabaseConfiguration { get; } = new DatabaseConfiguration
    {
        ConnectionString = configuration["Fridges:Database:ConnectionString"] ?? throw new Exception("Fridges:Database:ConnectionString is not set"),
        DbProvider = Enum.Parse<SupportedDbProvider>(configuration["Fridges:Database:DbProvider"] ?? "Sqlite", true),
    };

    // public IdentityConfiguration IdentityConfiguration { get; } = new IdentityConfiguration
    // {
    //     Options = new IdentityOptions
    //     {
    //         User = new UserOptions
    //         {
    //             AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
    //             RequireUniqueEmail = bool.Parse(configuration["Identity:Authentication:User:RequireUniqueEmail"] ?? "true")
    //         },
    //         Password = new PasswordOptions
    //         {
    //             RequiredLength = int.Parse(configuration["Identity:Authentication:Password:RequiredLength"] ?? "0"),
    //             RequiredUniqueChars = int.Parse(configuration["Identity:Authentication:Password:RequiredUniqueChars"] ?? "0"),
    //             RequireNonAlphanumeric = bool.Parse(configuration["Identity:Authentication:Password:RequireNonAlphanumeric"] ?? "false"),
    //             RequireLowercase = bool.Parse(configuration["Identity:Authentication:Password:RequireLowercase"] ?? "false"),
    //             RequireUppercase = bool.Parse(configuration["Identity:Authentication:Password:RequireUppercase"] ?? "false"),
    //             RequireDigit = bool.Parse(configuration["Identity:Authentication:Password:RequireDigit"] ?? "false")
    //         },
    //         SignIn = new SignInOptions
    //         {
    //             RequireConfirmedEmail = bool.Parse(configuration["Identity:Authentication:SignIn:RequireConfirmedEmail"] ?? "false"),
    //             RequireConfirmedPhoneNumber = bool.Parse(configuration["Identity:Authentication:SignIn:RequireConfirmedPhoneNumber"] ?? "false"),
    //             RequireConfirmedAccount = bool.Parse(configuration["Identity:Authentication:SignIn:RequireConfirmedAccount"] ?? "false")
    //         }
    //     }
    // };
    
    // public SeedDataConfiguration SeedDataConfiguration { get; } = new SeedDataConfiguration
    // {
    //     Seed = bool.Parse(configuration["Identity:SeedData:Seed"] ?? "false"),
    //     AdminId = Guid.Parse(configuration["Identity:SeedData:AdminId"] ?? throw new Exception("Identity:SeedData:AdminId is not set")),
    //     AdminPassword = configuration["Identity:SeedData:AdminPassword"] ?? throw new Exception("Identity:SeedData:AdminPassword is not set"),
    //     AdminEmail = configuration["Identity:SeedData:AdminEmail"] ?? throw new Exception("Identity:SeedData:AdminEmail is not set"),
    //     AdminUserName = configuration["Identity:SeedData:AdminUsername"] ?? throw new Exception("Identity:SeedData:AdminUsername is not set"),
    // };

    // public JwtTokenConfiguration JwtTokenConfiguration { get; } = new JwtTokenConfiguration
    // {
    //     Issuer = configuration["Identity:JwtToken:Issuer"] ?? throw new Exception("Identity:JwtToken:Issuer is not set"),
    //     Audience = configuration["Identity:JwtToken:Audience"] ?? throw new Exception("Identity:JwtToken:Audience is not set"),
    //     Secret = configuration["Identity:JwtToken:Secret"] ?? throw new Exception("Identity:JwtToken:Secret is not set"),
    //     ExpirationInSeconds = int.Parse(configuration["Identity:JwtToken:ExpirationInSeconds"] ?? "3600")
    // };
}