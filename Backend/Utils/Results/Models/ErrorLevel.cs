namespace Results.Models;

[Flags]
public enum ErrorLevel
{
    Debug,
    Important,
    Critical
}

public static class TraceLevelExtensions
{
    public static bool ClientError(this ErrorLevel errorLevel) =>
        (errorLevel.HasFlag(ErrorLevel.Important) || errorLevel.HasFlag(ErrorLevel.Critical)) && !errorLevel.HasFlag(ErrorLevel.Debug);
}