using Identity.Application.Common.Configuration.Models;

namespace Identity.Application.Common.Configuration;

public interface IIdentityApplicationConfiguration
{
    public IdentityFeaturesConfiguration IdentityFeatures { get; }
}