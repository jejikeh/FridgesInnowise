namespace Results.Models;

public class Success<TValue>
{
    public TValue Value { get; }

    public Success(TValue value)
    {
        Value = value;
    }
}