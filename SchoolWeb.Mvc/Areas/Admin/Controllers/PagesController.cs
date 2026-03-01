using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Services.Pages;
using SchoolWeb.Application.Shared;
using SchoolWeb.Mvc.Areas.Admin.Infrastructure;

namespace SchoolWeb.Mvc.Areas.Admin.Controllers;

[Area(AppConstants.Areas.Admin)]
[AdminAuthorize]
public sealed class PagesController : Controller
{
    private readonly IPageEditorService _editor;
    private readonly IMemoryCache _cache;

    public PagesController(IPageEditorService editor, IMemoryCache cache)
    {
        _editor = editor;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> Home(CancellationToken ct)
    {
        var result = await _editor.GetHomeEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new HomePageUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Home(HomePageUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateHomeAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        _cache.Remove(AppConstants.CacheKeys.Home);

        TempData["Success"] = "Saved.";
        return RedirectToAction(nameof(Home));
    }

    [HttpGet]
    public async Task<IActionResult> Footer(CancellationToken ct)
    {
        var result = await _editor.GetFooterEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new FooterContentUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Footer(FooterContentUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateFooterAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        _cache.Remove(AppConstants.CacheKeys.Footer);

        TempData["Success"] = "Footer updated.";
        return RedirectToAction(nameof(Footer));
    }

    [HttpGet]
    public async Task<IActionResult> SiteSettings(CancellationToken ct)
    {
        var result = await _editor.GetSiteSettingsEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new SiteSettingsUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SiteSettings(SiteSettingsUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateSiteSettingsAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        _cache.Remove(AppConstants.CacheKeys.SiteSettings);

        TempData["Success"] = "Settings updated.";
        return RedirectToAction(nameof(SiteSettings));
    }

    [HttpGet]
    public async Task<IActionResult> Contact(CancellationToken ct)
    {
        var result = await _editor.GetContactEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new ContactPageUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact(ContactPageUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateContactAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        TempData["Success"] = "Contact page updated.";
        return RedirectToAction(nameof(Contact));
    }

    [HttpGet]
    public async Task<IActionResult> History(CancellationToken ct)
    {
        var result = await _editor.GetHistoryEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new HistoryPageUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> History(HistoryPageUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateHistoryAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        TempData["Success"] = "History updated.";
        return RedirectToAction(nameof(History));
    }

    [HttpGet]
    public async Task<IActionResult> Mission(CancellationToken ct)
    {
        var result = await _editor.GetMissionEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new MissionPageUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Mission(MissionPageUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateMissionAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        TempData["Success"] = "Mission updated.";
        return RedirectToAction(nameof(Mission));
    }

    [HttpGet]
    public async Task<IActionResult> Organization(CancellationToken ct)
    {
        var result = await _editor.GetOrganizationEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new OrganizationPageUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Organization(OrganizationPageUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateOrganizationAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        TempData["Success"] = "Organization updated.";
        return RedirectToAction(nameof(Organization));
    }

    [HttpGet]
    public async Task<IActionResult> Links(CancellationToken ct)
    {
        var result = await _editor.GetLinksEditorAsync(ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddApiErrors(result);
            return View(new LinksPageUpdateDto());
        }

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Links(LinksPageUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _editor.UpdateLinksAsync(dto, ct);

        if (!result.IsSuccess)
        {
            ModelState.AddApiErrors(result);
            return View(dto);
        }

        TempData["Success"] = "Links updated.";
        return RedirectToAction(nameof(Links));
    }
}