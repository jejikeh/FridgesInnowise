namespace Identity.Application.Common.Models.Tokens;

public class RefreshToken(Guid userId, DateTime lifetime)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; init; } = userId;
    public string Token { get; init; } = Utils.GenerateStringByRandom(10);
    public DateTime Created { get; init; } = DateTime.UtcNow;
    public bool IsRevoked { get; set; } = false;
    public bool IsExpired => DateTime.UtcNow > Expires;

    private DateTime Expires { get; init; } = lifetime;
}