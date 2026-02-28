using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Mvc.Infrastructure;
using SchoolWeb.Mvc.ViewModels;

namespace SchoolWeb.Mvc.Controllers;

public class HomeController : BaseController
{
    private readonly IPageClient _pages;
    private readonly IPublicPageCache _cache;

    public HomeController(IPageClient pages, IPublicPageCache cache)
    {
        _pages = pages;
        _cache = cache;
    } 

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var model = await _cache.GetOrCreateAsync(
            key: "public.home",
            factory: async () =>
            {
                var r = await _pages.GetHomeAsync(ct);
                return r.IsSuccess ? r.Data : null;
            },
            ttl: TimeSpan.FromMinutes(10));

        if (model is null)
            return NotFound();

        this.SetSeo(new SeoViewModel
        {
            Title = model.SeoTitle,
            Description = model.SeoDescription,
            OgImageUrl = model.OgImageUrl
        });

        return View(model);
    }
}