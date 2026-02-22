using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolWeb.Application.Contracts;

namespace SchoolWeb.Mvc.Areas.Admin.Infrastructure;

public static class ModelStateExtensions
{
    public static void AddApiErrors(this ModelStateDictionary modelState, string? message, IReadOnlyList<string> errors)
    {
        if (!string.IsNullOrWhiteSpace(message))
            modelState.AddModelError(string.Empty, message);

        foreach (var e in errors)
        {
            if (!string.IsNullOrWhiteSpace(e))
                modelState.AddModelError(string.Empty, e);
        }
    }

    public static void AddApiErrors<T>(this ModelStateDictionary modelState, ApiResult<T> result)
        => modelState.AddApiErrors(result.Message, result.Errors);
}