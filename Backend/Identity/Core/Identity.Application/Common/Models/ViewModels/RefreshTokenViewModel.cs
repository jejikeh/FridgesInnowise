using Identity.Domain;

namespace Identity.Application.Common.Models.ViewModels;

public record RefreshTokenViewModel(string Token, DateTime ExpirationDate)
{
    public static RefreshTokenViewModel FromRefreshToken(RefreshToken refreshToken)
    {
        return new RefreshTokenViewModel(
            refreshToken.Token, 
            refreshToken.Expires
        );
    }
}