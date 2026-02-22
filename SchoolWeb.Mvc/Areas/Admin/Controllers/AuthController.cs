using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Application.Contracts.Auth;
using SchoolWeb.Application.Shared;
using SchoolWeb.Infrastructure.Auth;
using SchoolWeb.Mvc.Areas.Admin.Models;

namespace SchoolWeb.Mvc.Areas.Admin.Controllers;

[Area(AppConstants.Areas.Admin)]
public sealed class AuthController : Controller
{
    private readonly IAuthClient _authClient;
    private readonly ITokenStore _tokenStore;

    public AuthController(IAuthClient authClient, ITokenStore tokenStore)
    {
        _authClient = authClient;
        _tokenStore = tokenStore;
    }

    [HttpGet]
    public IActionResult Login() => View(new AdminLoginVm());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AdminLoginVm vm, CancellationToken ct)
    {
        foreach (var key in Request.Form.Keys)
    {
        Console.WriteLine($"{key} = {Request.Form[key]}");
    }
    
        if (!ModelState.IsValid)
            return View(vm);

        var result = await _authClient.LoginAsync(new LoginRequest
        {
            Email = vm.Email,
            Password = vm.Password
        }, ct);

        if (!result.IsSuccess || result.Data is null)
        {
            ModelState.AddModelError(string.Empty, result.Message ?? "Login failed.");
            return View(vm);
        }

        await _tokenStore.SetAsync(new TokenPair(result.Data.AccessToken, result.Data.RefreshToken));

        return RedirectToRoute("areas", new { area = AppConstants.Areas.Admin, controller = "Dashboard", action = "Index" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _tokenStore.ClearAsync();
        return RedirectToAction(nameof(Login));
    }
}
