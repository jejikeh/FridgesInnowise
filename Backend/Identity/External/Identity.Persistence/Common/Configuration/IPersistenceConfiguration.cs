using Identity.Persistence.Common.Configuration.Models;

namespace Identity.Persistence.Common.Configuration;

public interface IPersistenceConfiguration
{
    public DatabaseConfiguration DatabaseConfiguration { get; }
    public IdentityConfiguration IdentityConfiguration { get; }
}