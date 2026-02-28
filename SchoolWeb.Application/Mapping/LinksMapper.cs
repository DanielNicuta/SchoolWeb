using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class LinksMapper : IMapper<LinksPageResponseDto, LinksPageUpdateDto>
{
    public LinksPageUpdateDto Map(LinksPageResponseDto src) => new()
    {
        Title = src.Title,
        IntroHtml = src.IntroHtml,
        LinksHtml = src.LinksHtml,
        SeoTitle = src.SeoTitle,
        SeoDescription = src.SeoDescription,
        OgImageUrl = src.OgImageUrl
    };
}