using Identity.Application.Common.Models.Tokens;

namespace Identity.Application.Services;

public interface IAuthorizeTokenService
{
    public AuthorizeTokens GenerateAuthorizeToken(Guid userId, string email);
    public RefreshToken GenerateRandomRefreshToken(Guid userId);
    public Task<bool> ValidateAuthorizeTokenAsync(Guid userId, string token);
}