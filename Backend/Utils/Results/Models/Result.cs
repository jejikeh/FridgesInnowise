namespace Results.Models;

public class Result<TSuccess, TFailure> where TFailure : Error
{
    private TSuccess? _success { get; set; }
    private TFailure? _failure { get; set; }

    protected Result(TSuccess success)
    {
        _success = success;
        _failure = default!;
    }

    protected Result(TFailure failure)
    {
        _success = default!;
        _failure = failure;
    }
    
    public static Result<TSuccess, TFailure> Success(TSuccess success) => new Result<TSuccess, TFailure>(success);
    public static Result<TSuccess, TFailure> Failure(TFailure failure) => new Result<TSuccess, TFailure>(failure);
    
    public bool IsSuccess => _success != null;
    public bool IsFailure => _failure != null;
    
    public TSuccess? GetSuccess() => _success;
    public TFailure? GetFailure() => _failure;
    
    public static implicit operator Result<TSuccess, TFailure>(TSuccess success) => Success(success);
    public static implicit operator Result<TSuccess, TFailure>(TFailure failure) => Failure(failure);
}