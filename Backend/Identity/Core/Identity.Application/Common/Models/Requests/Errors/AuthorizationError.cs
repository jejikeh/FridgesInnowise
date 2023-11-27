using Results.Models;

namespace Identity.Application.Common.Models.Requests.Errors;

public class AuthorizationError : Error
{
    private AuthorizationError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static AuthorizationError InvalidToken() => new AuthorizationError("Invalid token", 400, ErrorLevel.Critical);
}