using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Mvc.Areas.Admin.Controllers;

[Area(AppConstants.Areas.Admin)]
public sealed class DashboardController : Controller
{
    [HttpGet]
    public IActionResult Index() => View();
}