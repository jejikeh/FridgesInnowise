namespace Results.Models;

public class Success<TValue>
{
    public TValue Value { get; }
    public bool Visible { get; set; }

    public Success(TValue value, bool visible = true)
    {
        Value = value;
        Visible = visible;
    }
}