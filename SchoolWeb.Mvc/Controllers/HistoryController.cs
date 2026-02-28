using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Mvc.Infrastructure;

namespace SchoolWeb.Mvc.Controllers;

public sealed class HistoryController : Controller
{
    private readonly IPageClient _pages;
    private readonly IPublicPageCache _cache;

    public HistoryController(IPageClient pages, IPublicPageCache cache)
    {
        _pages = pages;
        _cache = cache;
    }

    [HttpGet("/history")]
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var model = await _cache.GetOrCreateAsync(
            key: "public.history",
            factory: async () =>
            {
                var r = await _pages.GetHistoryAsync(ct);
                return r.IsSuccess ? r.Data : null;
            },
            ttl: TimeSpan.FromMinutes(10));

        if (model is null)
            return NotFound();

        return View(model);
    }
}