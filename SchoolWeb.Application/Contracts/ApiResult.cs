namespace SchoolWeb.Application.Contracts;

/// <summary>
/// Normalized result used inside MVC app (not tied to transport).
/// </summary>
public sealed class ApiResult<T>
{
    private ApiResult(bool isSuccess, T? data, string? message, IReadOnlyList<string>? errors)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
        Errors = errors ?? Array.Empty<string>();
    }

    public bool IsSuccess { get; }
    public T? Data { get; }
    public string? Message { get; }
    public IReadOnlyList<string> Errors { get; }

    public static ApiResult<T> Ok(T data, string? message = null) =>
        new(true, data, message, null);

    public static ApiResult<T> Fail(string? message, IReadOnlyList<string>? errors = null) =>
        new(false, default, message, errors);
}
