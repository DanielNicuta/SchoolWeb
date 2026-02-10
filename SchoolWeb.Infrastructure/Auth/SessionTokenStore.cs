using System.Text.Json;
using Microsoft.AspNetCore.Http;
using SchoolWeb.Infrastructure.Serialization;

namespace SchoolWeb.Infrastructure.Auth;

public sealed class SessionTokenStore : ITokenStore
{
    private const string SessionKey = "auth:tokens"; // one place; not scattered

    private readonly IHttpContextAccessor _http;

    public SessionTokenStore(IHttpContextAccessor http) => _http = http;

    public Task<TokenPair?> GetAsync()
    {
        var ctx = _http.HttpContext;
        if (ctx is null) return Task.FromResult<TokenPair?>(null);

        var json = ctx.Session.GetString(SessionKey);
        if (string.IsNullOrWhiteSpace(json)) return Task.FromResult<TokenPair?>(null);

        return Task.FromResult(JsonSerializer.Deserialize<TokenPair>(json, JsonDefaults.Options));
    }

    public Task SetAsync(TokenPair tokens)
    {
        var ctx = _http.HttpContext ?? throw new InvalidOperationException("No HttpContext available.");
        var json = JsonSerializer.Serialize(tokens, JsonDefaults.Options);
        ctx.Session.SetString(SessionKey, json);
        return Task.CompletedTask;
    }

    public Task ClearAsync()
    {
        _http.HttpContext?.Session.Remove(SessionKey);
        return Task.CompletedTask;
    }
}
