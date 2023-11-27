using Identity.Application.Common.Models.Tokens;

namespace Identity.Application.Common.Models.ViewModels;

public class AuthorizeTokensViewModel
{
    public Guid UserId { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public required RefreshTokenViewModel RefreshToken { get; set; }

    public static AuthorizeTokensViewModel FromAuthorizeTokens(AuthorizeTokens tokens)
    {
        return new AuthorizeTokensViewModel
        {
            UserId = tokens.Id,
            AccessToken = tokens.AccessToken,
            RefreshToken = RefreshTokenViewModel.FromRefreshToken(tokens.RefreshToken)
        };
    }
}