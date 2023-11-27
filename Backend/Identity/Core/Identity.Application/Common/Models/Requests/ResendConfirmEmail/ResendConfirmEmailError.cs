using Results.Models;

namespace Identity.Application.Common.Models.Requests.ResendConfirmEmail;

public class ResendConfirmEmailError : Error
{
    public ResendConfirmEmailError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static ResendConfirmEmailError UserNotFound() => new ResendConfirmEmailError("User not found", 400, ErrorLevel.Critical);
    public static ResendConfirmEmailError UserAlreadyConfirmed() => new ResendConfirmEmailError("User already confirmed", 400, ErrorLevel.Critical);
}