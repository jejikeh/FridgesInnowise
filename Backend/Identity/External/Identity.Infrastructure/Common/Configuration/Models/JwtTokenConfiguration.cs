namespace Identity.Infrastructure.Common.Configuration.Models;

public class JwtTokenConfiguration
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public int ExpirationInSeconds { get; set; }
}