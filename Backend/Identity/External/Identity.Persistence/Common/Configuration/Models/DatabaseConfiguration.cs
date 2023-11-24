namespace Identity.Persistence.Common.Configuration.Models;

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; } = string.Empty;
    public SupportedDbProvider DbProvider { get; set; }
}