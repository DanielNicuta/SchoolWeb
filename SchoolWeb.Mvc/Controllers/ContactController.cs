using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Mvc.Infrastructure;

namespace SchoolWeb.Mvc.Controllers;

public sealed class ContactController : Controller
{
    private readonly IPageClient _pages;
    private readonly IPublicPageCache _cache;

    public ContactController(IPageClient pages, IPublicPageCache cache)
    {
        _pages = pages;
        _cache = cache;
    }

    [HttpGet("/contact")]
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var model = await _cache.GetOrCreateAsync(
            key: "public.contact",
            factory: async () =>
            {
                var r = await _pages.GetContactAsync(ct);
                return r.IsSuccess ? r.Data : null;
            },
            ttl: TimeSpan.FromMinutes(10));

        if (model is null)
            return NotFound();

        return View(model);
    }
}