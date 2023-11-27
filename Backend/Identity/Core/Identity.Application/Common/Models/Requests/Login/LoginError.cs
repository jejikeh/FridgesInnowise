using Results.Models;

namespace Identity.Application.Common.Models.Requests.Login;

public class LoginError : Error
{
    public LoginError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static LoginError InvalidCredentials() => new LoginError("Invalid credentials", 400, ErrorLevel.Critical);
    public static LoginError EmailIsNotConfirmed() => new LoginError("Email is not confirmed", 400, ErrorLevel.Critical);
}