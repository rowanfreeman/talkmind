namespace TalkMind.Api.Common;

internal sealed class Result<TSuccess, TFailure>
{
    private TSuccess? _successValue { get; }

    private TFailure? _failureValue { get; }

    private bool _isSuccess => _successValue is not null;

    private Result(TSuccess successValue) => _successValue = successValue;

    private Result(TFailure failureValue) => _failureValue = failureValue;

    internal static Result<TSuccess, TFailure> Success(TSuccess success) => new(success);

    internal static Result<TSuccess, TFailure> Failure(TFailure failure) => new(failure);

    internal TResult Match<TResult>(
        Func<TSuccess, TResult> onSuccess,
        Func<TFailure, TResult> onFailure
    ) => _isSuccess ? onSuccess(_successValue!) : onFailure(_failureValue!);
}