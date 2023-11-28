using Fridges.Persistence.Common.Configuration.Models;

namespace Fridges.Persistence.Common.Configuration;

public interface IFridgesPersistenceConfiguration
{
    public DatabaseConfiguration DatabaseConfiguration { get; }
}