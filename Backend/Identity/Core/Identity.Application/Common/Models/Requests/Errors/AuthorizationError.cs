using Results.Models;

namespace Identity.Application.Common.Models.Requests.Errors;

public class AuthorizationError : Error
{
    public AuthorizationError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
}