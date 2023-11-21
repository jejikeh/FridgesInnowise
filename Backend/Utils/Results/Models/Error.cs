namespace Results.Models;

public class Error
{
    public Error(string message, int httpStatusCode, ErrorLevel level = ErrorLevel.Debug, Error[]? innerErrors = null)
    {
        Message = message;
        HttpStatusCode = httpStatusCode;
        Level = level;

        if (innerErrors is not null)
        {
            InnerErrors = innerErrors.ToList();
        }
    }

    public string Message { get; }
    public int HttpStatusCode { get; }
    public ErrorLevel Level { get; }
    public List<Error> InnerErrors { get; init; } = new List<Error>();

    public static T InternalError<T>(params Error[] innerErrors) where T : Error
    {
        return (new Error(
            "Internal error",
            500,
            ErrorLevel.Critical | ErrorLevel.Important,
            innerErrors) as T)!;
    }
}