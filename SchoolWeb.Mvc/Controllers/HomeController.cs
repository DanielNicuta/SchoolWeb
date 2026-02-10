using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts.Public;

namespace SchoolWeb.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly IPublicContentClient _publicContent;

    public HomeController(IPublicContentClient publicContent)
    {
        _publicContent = publicContent;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await _publicContent.GetHomeAsync(ct);

        if (!result.IsSuccess)
        {
            ViewBag.Error = result.Message ?? "Error loading home page.";
            return View(model: null);
        }

        return View(result.Data);
    }
}
