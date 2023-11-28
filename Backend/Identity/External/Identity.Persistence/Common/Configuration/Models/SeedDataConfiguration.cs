namespace Identity.Persistence.Common.Configuration.Models;

public class SeedDataConfiguration
{
    public bool Seed { get; set; }
    public Guid AdminId { get; set; }
    public string AdminEmail { get; set; } = string.Empty;
    public string AdminPassword { get; set; } = string.Empty;
    public string AdminUserName { get; set; } = string.Empty;
}