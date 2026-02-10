namespace SchoolWeb.Application.Contracts;

/// <summary>
/// Matches API wrapper: success/data/message/errors.
/// </summary>
public sealed class ApiResponse<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public string? Message { get; init; }
    public IReadOnlyList<string>? Errors { get; init; }
}
