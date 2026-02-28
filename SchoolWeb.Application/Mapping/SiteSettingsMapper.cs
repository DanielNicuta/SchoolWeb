using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class SiteSettingsMapper : IMapper<SiteSettingsResponseDto, SiteSettingsUpdateDto>
{
    public SiteSettingsUpdateDto Map(SiteSettingsResponseDto src) => new()
    {
        SiteName = src.SiteName,
        LogoUrl = src.LogoUrl,
        FaviconUrl = src.FaviconUrl,
        DefaultLanguage = src.DefaultLanguage,

        ContactEmail = src.ContactEmail,
        ContactPhone = src.ContactPhone,
        Address = src.Address,

        FacebookUrl = src.FacebookUrl,
        YoutubeUrl = src.YoutubeUrl,
        TwitterUrl = src.TwitterUrl,

        CookieBannerText = src.CookieBannerText
    };
}