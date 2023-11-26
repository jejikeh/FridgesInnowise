using Identity.Infrastructure.Common.Configuration.Models;

namespace Identity.Infrastructure.Common.Configuration;

public interface IIdentityInfrastructureConfiguration
{
    public EmailConfiguration EmailConfiguration { get; }
    public string Host { get; }
}