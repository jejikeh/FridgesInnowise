using Results.Models;

namespace Identity.Application.Common.Models.Requests.UpdateAuthorizeToken;

public class UpdateAuthorizeTokenError : Error
{
    public UpdateAuthorizeTokenError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static UpdateAuthorizeTokenError UserNotFound() => new UpdateAuthorizeTokenError("User not found", 400, ErrorLevel.Critical);
    public static UpdateAuthorizeTokenError InvalidToken() => new UpdateAuthorizeTokenError("Invalid token", 400, ErrorLevel.Critical);
}