using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolWeb.Infrastructure.Auth;

namespace SchoolWeb.Mvc.Areas.Admin.Infrastructure;

public sealed class AdminAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var tokenStore = context.HttpContext.RequestServices
            .GetRequiredService<ITokenStore>();

        var tokens = await tokenStore.GetAsync();

        if (tokens is null)
        {
            context.Result = new RedirectToActionResult(
                "Login",
                "Auth",
                new { area = "Admin" });
        }
    }
}