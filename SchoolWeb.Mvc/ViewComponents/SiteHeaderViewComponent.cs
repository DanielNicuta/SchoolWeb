using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Mvc.ViewComponents;

public sealed class SiteHeaderViewComponent : ViewComponent
{
    private readonly IPageClient _pages;
    private readonly IMemoryCache _cache;

    public SiteHeaderViewComponent(IPageClient pages, IMemoryCache cache)
    {
        _pages = pages;
        _cache = cache;
    }

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken ct)
    {
        var settings = await _cache.GetOrCreateAsync(AppConstants.CacheKeys.SiteSettings, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            var result = await _pages.GetSiteSettingsAsync(ct);
            return result.IsSuccess ? result.Data : null;
        });

        return View(settings);
    }
}