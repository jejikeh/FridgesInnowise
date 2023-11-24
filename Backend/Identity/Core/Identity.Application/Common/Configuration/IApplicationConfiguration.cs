using Identity.Application.Common.Configuration.Models;

namespace Identity.Application.Common.Configuration;

public interface IApplicationConfiguration
{
    public FeaturesConfiguration Features { get; }
}