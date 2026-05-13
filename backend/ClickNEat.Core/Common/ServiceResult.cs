namespace ClickNEat.Core.Common;

public sealed class ServiceResult<T>
{
    public bool IsSuccess { get; private init; }
    public T? Value { get; private init; }
    public string? Error { get; private init; }
    public int StatusCode { get; private init; }

    public static ServiceResult<T> Ok(T value) =>
        new() { IsSuccess = true, Value = value, StatusCode = 200 };

    public static ServiceResult<T> Fail(string error, int statusCode = 400) =>
        new() { IsSuccess = false, Error = error, StatusCode = statusCode };

    public static ServiceResult<T> NotFound(string? error = null) =>
        Fail(error ?? "Not found", 404);

    public static ServiceResult<T> Forbidden(string? error = null) =>
        Fail(error ?? "Forbidden", 403);

    public static ServiceResult<T> Conflict(string error) =>
        Fail(error, 409);

    public static ServiceResult<T> Unauthorized(string? error = null) =>
        Fail(error ?? "Unauthorized", 401);
}
