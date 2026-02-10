using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using SchoolWeb.Application.Contracts;
using SchoolWeb.Infrastructure.Serialization;

namespace SchoolWeb.Infrastructure.Http;

public sealed class ApiClient : IApiClient
{
    private readonly HttpClient _http;
    private readonly ILogger<ApiClient> _logger;

    public ApiClient(HttpClient http, ILogger<ApiClient> logger)
    {
        _http = http;
        _logger = logger;
    }

    public Task<ApiResult<T>> GetAsync<T>(string path, CancellationToken ct) =>
        SendAsync<object, T>(HttpMethod.Get, path, null, ct);

    public Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string path, TRequest body, CancellationToken ct) =>
        SendAsync<TRequest, TResponse>(HttpMethod.Post, path, body, ct);

    public Task<ApiResult<TResponse>> PutAsync<TRequest, TResponse>(string path, TRequest body, CancellationToken ct) =>
        SendAsync<TRequest, TResponse>(HttpMethod.Put, path, body, ct);

    private async Task<ApiResult<TResponse>> SendAsync<TRequest, TResponse>(
        HttpMethod method,
        string path,
        TRequest? body,
        CancellationToken ct)
    {
        try
        {
            using var request = new HttpRequestMessage(method, path);

            if (body is not null && method != HttpMethod.Get)
            {
                request.Content = JsonContent.Create(body, options: JsonDefaults.Options);
            }

            using var response = await _http.SendAsync(request, ct);

            // Prefer wrapper JSON response if available
            ApiResponse<TResponse>? wrapper = null;

            if (response.Content is not null)
            {
                // Even for non-2xx, API might return wrapper with errors/message
                wrapper = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>(JsonDefaults.Options, ct);
            }

            // If API returned wrapper, use it
            if (wrapper is not null)
            {
                if (wrapper.Success)
                {
                    if (wrapper.Data is null)
                        return ApiResult<TResponse>.Fail(wrapper.Message ?? "API returned success but data was null.");

                    return ApiResult<TResponse>.Ok(wrapper.Data, wrapper.Message);
                }

                return ApiResult<TResponse>.Fail(wrapper.Message, wrapper.Errors);
            }

            // Fallback if wrapper is not returned
            if (response.IsSuccessStatusCode)
            {
                if (response.Content is null) 
                {
                    return ApiResult<TResponse>.Fail(
                        $"API call failed with status {(int)response.StatusCode} ({response.StatusCode}).");
                }
                var data = await response.Content.ReadFromJsonAsync<TResponse>(JsonDefaults.Options, ct);
                if (data is null)
                    return ApiResult<TResponse>.Fail("API returned success but response body was empty.");

                return ApiResult<TResponse>.Ok(data);
            }

            return ApiResult<TResponse>.Fail(
                $"API call failed with status {(int)response.StatusCode} ({response.StatusCode}).");
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
            // Caller canceled
            throw;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP request error for {Method} {Path}", method, path);
            return ApiResult<TResponse>.Fail("Network error while calling API.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error for {Method} {Path}", method, path);
            return ApiResult<TResponse>.Fail("Unexpected error while calling API.");
        }
    }
}
