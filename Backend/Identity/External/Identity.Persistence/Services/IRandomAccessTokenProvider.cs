using Identity.Domain;

namespace Identity.Persistence.Services;

public interface IRandomAccessTokenProvider
{
    public string GenerateRandomToken(Guid userId, string email);
}