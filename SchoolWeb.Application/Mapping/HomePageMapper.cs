using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class HomePageMapper : IMapper<HomePageResponseDto, HomePageUpdateDto>
{
    public HomePageUpdateDto Map(HomePageResponseDto src) => new()
    {
        HeroTitle = src.HeroTitle,
        HeroSubtitle = src.HeroSubtitle,
        HeroButtonText = src.HeroButtonText,
        HeroButtonUrl = src.HeroButtonUrl,
        HeroImageUrl = src.HeroImageUrl,

        AboutTitle = src.AboutTitle,
        AboutSubtitle = src.AboutSubtitle,
        AboutHtml = src.AboutHtml,
        AboutImageUrl = src.AboutImageUrl,

        Highlight1Title = src.Highlight1Title,
        Highlight1Text = src.Highlight1Text,
        Highlight1Icon = src.Highlight1Icon,

        Highlight2Title = src.Highlight2Title,
        Highlight2Text = src.Highlight2Text,
        Highlight2Icon = src.Highlight2Icon,

        Highlight3Title = src.Highlight3Title,
        Highlight3Text = src.Highlight3Text,
        Highlight3Icon = src.Highlight3Icon,

        SeoTitle = src.SeoTitle,
        SeoDescription = src.SeoDescription,
        OgImageUrl = src.OgImageUrl
    };
}