using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using SchoolWeb.Application.Contracts.Auth;

namespace SchoolWeb.Infrastructure.Auth;

public sealed class ApiAuthHandler : DelegatingHandler
{
    private readonly ITokenStore _tokenStore;
    private readonly IAuthClient _authClient;
    private readonly ILogger<ApiAuthHandler> _logger;

    public ApiAuthHandler(
        ITokenStore tokenStore,
        IAuthClient authClient,
        ILogger<ApiAuthHandler> logger)
    {
        _tokenStore = tokenStore;
        _authClient = authClient;
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var tokens = await _tokenStore.GetAsync();
        if (tokens is not null)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

        var response = await base.SendAsync(request, ct);

        // If unauthorized, try refresh once
        if (response.StatusCode != HttpStatusCode.Unauthorized || tokens is null)
            return response;

        _logger.LogInformation("Received 401. Attempting token refresh.");

        var refreshResult = await _authClient.RefreshAsync(
            new RefreshRequest { RefreshToken = tokens.RefreshToken },
            ct);

        if (!refreshResult.IsSuccess || refreshResult.Data is null)
        {
            _logger.LogWarning("Token refresh failed. Clearing session tokens.");
            await _tokenStore.ClearAsync();
            return response;
        }

        await _tokenStore.SetAsync(new TokenPair(
            refreshResult.Data.AccessToken,
            refreshResult.Data.RefreshToken));

        // Retry original request once with new access token
        response.Dispose();

        var retry = await CloneAsync(request);
        retry.Headers.Authorization = new AuthenticationHeaderValue("Bearer", refreshResult.Data.AccessToken);

        return await base.SendAsync(retry, ct);
    }

    private static async Task<HttpRequestMessage> CloneAsync(HttpRequestMessage request)
    {
        var clone = new HttpRequestMessage(request.Method, request.RequestUri);

        foreach (var header in request.Headers)
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

        if (request.Content is not null)
        {
            var ms = new MemoryStream();
            await request.Content.CopyToAsync(ms);
            ms.Position = 0;

            clone.Content = new StreamContent(ms);

            foreach (var header in request.Content.Headers)
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return clone;
    }
}
