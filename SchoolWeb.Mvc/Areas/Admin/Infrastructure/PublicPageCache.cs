using Microsoft.Extensions.Caching.Memory;

namespace SchoolWeb.Mvc.Infrastructure;

public interface IPublicPageCache
{
    Task<T?> GetOrCreateAsync<T>(string key, Func<Task<T?>> factory, TimeSpan ttl);
}

public sealed class PublicPageCache : IPublicPageCache
{
    private readonly IMemoryCache _cache;

    public PublicPageCache(IMemoryCache cache) => _cache = cache;

    public Task<T?> GetOrCreateAsync<T>(string key, Func<Task<T?>> factory, TimeSpan ttl)
    {
        return _cache.GetOrCreateAsync(key, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = ttl;
            return await factory();
        });
    }
}