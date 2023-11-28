using Results.Models;

namespace Identity.Application.Common.Models.Requests.GetRefreshTokens;

public class GetRefreshTokensError : Error
{
    public GetRefreshTokensError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static GetRefreshTokensError UserNotFound() => new GetRefreshTokensError("User not found", 400, ErrorLevel.Critical);
}