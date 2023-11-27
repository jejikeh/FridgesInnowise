using Identity.Application.Common.Models.Tokens;
using Identity.Application.Services;
using Identity.Domain;
using Identity.Persistence.Common.Configuration;
using Identity.Persistence.Common.Configuration.Models;

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
        
        context.RefreshTokens.Add(refreshToken);
        context.SaveChanges();
        
        return refreshToken;
    }

    public Task<bool> ValidateAuthorizeTokenAsync(Guid userId, string token)
    {
        var refreshToken = context.RefreshTokens.FirstOrDefault(x => x.UserId == userId && x.Token == token);
        
        return Task.FromResult(refreshToken is
        {
            IsRevoked: false, 
            IsExpired: false
        });
    }
}