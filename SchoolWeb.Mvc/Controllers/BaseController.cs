using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts;

namespace SchoolWeb.Mvc.Controllers;

public abstract class BaseController : Controller
{
    protected IActionResult HandleFailure<T>(ApiResult<T> result)
    {
        // Later we’ll map errors to resource strings and a nicer error page
        ViewBag.Error = result.Message ?? "Request failed.";
        ViewBag.Errors = result.Errors;
        return View("Error");
    }
}
