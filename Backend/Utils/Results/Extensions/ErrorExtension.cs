using Results.Models;

namespace Results.Extensions;

public static class ErrorExtension 
{
    public static Error LeaveClientErrors(this Error error)
    {
        return new Error(error.Message, error.HttpStatusCode, error.Level)
        {
            InnerErrors = FilterVisibleError(error)
        };
    }
    
    private static List<Error> FilterVisibleError(Error error)
    {
        return FilterError(error, level => level.ClientError());
    }
    
    private static List<Error> FilterError(Error error, Func<ErrorLevel, bool> predicate)
    {
        var filteredErrors = new List<Error>();
        foreach (var err in error.InnerErrors)
        {
            if (err.InnerErrors.Any())
            {
                filteredErrors.AddRange(FilterVisibleError(err));
            }
            
            if (predicate(err.Level))
            {
                filteredErrors.Add(err);
            }
        }
        
        return filteredErrors;
    }
}