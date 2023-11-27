namespace Identity.Application.Common.Models.Tokens;

public record AuthorizeTokens(Guid Id, string AccessToken, RefreshToken RefreshToken);
