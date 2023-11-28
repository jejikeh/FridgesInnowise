using Identity.Application.Common.Models.Requests.Errors;
using Identity.Application.Common.Models.Tokens;
using Identity.Domain;
using Results.Models;

namespace Identity.Application.Services;

public interface IAuthorizeTokenService
{
    public AuthorizeTokens GenerateAuthorizeToken(Guid userId, string email);
    public RefreshToken GenerateRandomRefreshToken(Guid userId);
    public AuthorizeTokens GenerateAccessTokenUsingRefreshToken(Guid userId, string email, RefreshToken refreshToken);
    public Task<Result<RefreshToken, AuthorizationError>> ValidateAuthorizeTokenAsync(Guid userId, string token);
    public Task<List<RefreshToken>> GetRefreshTokensAsync(Guid userId);
}