using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Mvc.Controllers;

public class HomeController : BaseController
{
    private readonly IPageClient _pages;

    public HomeController(IPageClient pages) => _pages = pages;

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await _pages.GetHomeAsync(ct);

        if (!result.IsSuccess || result.Data is null)
            return HandleFailure(result);

        return View(result.Data);
    }
}