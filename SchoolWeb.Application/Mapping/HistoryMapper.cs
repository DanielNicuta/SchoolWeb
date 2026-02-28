using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class HistoryMapper : IMapper<HistoryPageResponseDto, HistoryPageUpdateDto>
{
    public HistoryPageUpdateDto Map(HistoryPageResponseDto src) => new()
    {
        Title = src.Title,
        Subtitle = src.Subtitle,
        ContentHtml = src.ContentHtml,
        SideImageUrl = src.SideImageUrl,
        SeoTitle = src.SeoTitle,
        SeoDescription = src.SeoDescription,
        OgImageUrl = src.OgImageUrl
    };
}