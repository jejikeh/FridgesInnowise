using Results.Models;

namespace Identity.Application.Common.Models.Requests.Errors;

public class NotFoundError : Error
{
    public NotFoundError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static NotFoundError UserNotFound() => new NotFoundError("User not found", 403, ErrorLevel.Critical);
    public static NotFoundError TokenNotFound() => new NotFoundError("Token not found", 403, ErrorLevel.Critical);
}