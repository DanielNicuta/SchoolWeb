using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Shared;
using SchoolWeb.Mvc.Areas.Admin.Infrastructure;

namespace SchoolWeb.Mvc.Areas.Admin.Controllers;

[Area(AppConstants.Areas.Admin)]
[Authorize(Roles = "Admin")]
public sealed class PagesController : Controller
{
    private readonly IPageClient _pages;         // GET current (public endpoint is ok)
    private readonly IAdminPageClient _admin;    // PUT update (authorized)

    public PagesController(IPageClient pages, IAdminPageClient admin)
    {
        _pages = pages;
        _admin = admin;
    }

    // GET: /Admin/Pages/Home
    [HttpGet]
    public async Task<IActionResult> Home(CancellationToken ct)
    {
        var result = await _pages.GetHomeAsync(ct);
        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new HomePageUpdateDto()); // empty fallback
        }

        // Map ResponseDto -> UpdateDto (explicit mapping; no magic)
        var vm = MapToUpdate(result.Data);
        return View(vm);
    }

    // POST: /Admin/Pages/Home
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Home(HomePageUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var update = await _admin.UpdateHomeAsync(dto, ct);
        if (!update.IsSuccess || update.Data is null)
        {
            ModelState.AddApiErrors(update);
            return View(dto);
        }

        TempData["Success"] = "Saved.";
        return RedirectToAction(nameof(Home));
    }

    private static HomePageUpdateDto MapToUpdate(HomePageResponseDto src)
    {
        return new HomePageUpdateDto
        {
            HeroTitle = src.HeroTitle,
            HeroSubtitle = src.HeroSubtitle,
            HeroButtonText = src.HeroButtonText,
            HeroButtonUrl = src.HeroButtonUrl,
            HeroImageUrl = src.HeroImageUrl,

            AboutTitle = src.AboutTitle,
            AboutSubtitle = src.AboutSubtitle,
            AboutHtml = src.AboutHtml,
            AboutImageUrl = src.AboutImageUrl,

            Highlight1Title = src.Highlight1Title,
            Highlight1Text = src.Highlight1Text,
            Highlight1Icon = src.Highlight1Icon,

            Highlight2Title = src.Highlight2Title,
            Highlight2Text = src.Highlight2Text,
            Highlight2Icon = src.Highlight2Icon,

            Highlight3Title = src.Highlight3Title,
            Highlight3Text = src.Highlight3Text,
            Highlight3Icon = src.Highlight3Icon,

            SeoTitle = src.SeoTitle,
            SeoDescription = src.SeoDescription,
            OgImageUrl = src.OgImageUrl
        };
    }
}