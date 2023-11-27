using Identity.Infrastructure.Common.Configuration.Models;

namespace Identity.Infrastructure.Common.Configuration;

public interface IIdentityInfrastructureConfiguration
{
    public EmailConfiguration EmailConfiguration { get; }
    public JwtTokenConfiguration JwtTokenConfiguration { get; }
    public string Host { get; }
}