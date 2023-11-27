using Identity.Application.Common.Models.Requests.Errors;
using Identity.Application.Common.Models.Tokens;
using Identity.Application.Services;
using Identity.Domain;
using Identity.Persistence.Common.Configuration;
using Identity.Persistence.Common.Configuration.Models;
using Microsoft.EntityFrameworkCore;
using Results.Models;

namespace Identity.Persistence.Services;

public class AuthorizeTokenService(
    IdentityDbContext context,
    IRandomAccessTokenProvider randomAccessTokenProvider,
    IIdentityPersistenceConfiguration configuration) : IAuthorizeTokenService
{
    private readonly RefreshTokenConfiguration _refreshTokenConfiguration
        = configuration.RefreshTokenConfiguration;

    public AuthorizeTokens GenerateAuthorizeToken(Guid userId, string email)
    {
        var token = randomAccessTokenProvider.GenerateRandomToken(userId, email);
        var refreshToken = GenerateRandomRefreshToken(userId);

        return new AuthorizeTokens(userId, token, refreshToken);
    }

    public RefreshToken GenerateRandomRefreshToken(Guid userId)
    {
        var refreshToken = new RefreshToken(
            userId,
            DateTime
                .UtcNow
                .AddSeconds(_refreshTokenConfiguration.RefreshTokenValidityInSeconds));

        var entity = context.RefreshTokens.Add(refreshToken);
        context.SaveChanges();

        return entity.Entity;
    }

    public AuthorizeTokens GenerateAccessTokenUsingRefreshToken(Guid userId, string email, RefreshToken refreshToken)
    {
        return new AuthorizeTokens(userId, randomAccessTokenProvider.GenerateRandomToken(userId, email), refreshToken);
    }

    public async Task<Result<RefreshToken, AuthorizationError>> ValidateAuthorizeTokenAsync(Guid userId, string token)
    {
        var refreshToken = await context.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId && x.Token == token);
        if (refreshToken is null or
            {
                IsRevoked: false,
                IsExpired: false
            })
        {
            return AuthorizationError.InvalidToken();
        }

        return refreshToken!;
    }
}