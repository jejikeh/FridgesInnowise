
namespace Fridges.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string? errorMessage = null) : base(errorMessage)
    {
    }
}