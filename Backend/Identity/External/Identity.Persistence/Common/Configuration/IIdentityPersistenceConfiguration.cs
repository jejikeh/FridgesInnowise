using Identity.Persistence.Common.Configuration.Models;

namespace Identity.Persistence.Common.Configuration;

public interface IIdentityPersistenceConfiguration
{
    public DatabaseConfiguration DatabaseConfiguration { get; }
    public IdentityConfiguration IdentityConfiguration { get; }
    public RefreshTokenConfiguration RefreshTokenConfiguration { get; }
    public SeedDataConfiguration SeedDataConfiguration { get; }
}