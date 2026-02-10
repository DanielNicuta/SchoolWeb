using SchoolWeb.Application.Contracts;

namespace SchoolWeb.Infrastructure.Http;

public interface IApiClient
{
    Task<ApiResult<T>> GetAsync<T>(string path, CancellationToken ct);
    Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string path, TRequest body, CancellationToken ct);
    Task<ApiResult<TResponse>> PutAsync<TRequest, TResponse>(string path, TRequest body, CancellationToken ct);
}
