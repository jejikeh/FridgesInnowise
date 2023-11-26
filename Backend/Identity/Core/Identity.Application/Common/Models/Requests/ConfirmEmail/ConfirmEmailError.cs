using Results.Models;

namespace Identity.Application.Common.Models.Requests.ConfirmEmail;

public class ConfirmEmailError : Error
{
    public ConfirmEmailError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static ConfirmEmailError WrongToken() => new ConfirmEmailError("Wrong token", 400, ErrorLevel.Critical);
    public static ConfirmEmailError UserNotFound() => new ConfirmEmailError("User not found", 400, ErrorLevel.Critical);
    public static ConfirmEmailError UserAlreadyConfirmed() => new ConfirmEmailError("User already confirmed", 400, ErrorLevel.Critical);
}