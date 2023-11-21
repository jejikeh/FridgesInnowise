using Results.Models;

namespace Identity.Application.Common.Models.Requests.Register;

public class RegisterError : Error
{
    public RegisterError(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null) : base(message, httpStatusCode, level, innerErrors)
    {
    }
    
    public static RegisterError WrongPassword() => new RegisterError("Wrong password", 400, ErrorLevel.Critical);
    public static RegisterError UserAlreadyExists() => new RegisterError("User already exists", 400, ErrorLevel.Critical);
    public static RegisterError InvalidEmail() => new RegisterError("Invalid email", 400, ErrorLevel.Critical);
}