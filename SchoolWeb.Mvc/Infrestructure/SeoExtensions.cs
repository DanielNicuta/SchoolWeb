using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SchoolWeb.Mvc.ViewModels;

namespace SchoolWeb.Mvc.Infrastructure;

public static class SeoExtensions
{
    private const string SeoKey = "Seo";

    public static void SetSeo(this Controller controller, SeoViewModel seo)
    {
        controller.ViewData[SeoKey] = seo;
    }

    public static SeoViewModel? GetSeo(this ViewDataDictionary viewData)
    {
        return viewData.TryGetValue(SeoKey, out var value) ? value as SeoViewModel : null;
    }
}