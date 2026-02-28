using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class MissionMapper : IMapper<MissionPageResponseDto, MissionPageUpdateDto>
{
    public MissionPageUpdateDto Map(MissionPageResponseDto src) => new()
    {
        Title = src.Title,
        IntroHtml = src.IntroHtml,
        MissionHtml = src.MissionHtml,
        ImageUrl = src.ImageUrl,
        SeoTitle = src.SeoTitle,
        SeoDescription = src.SeoDescription,
        OgImageUrl = src.OgImageUrl
    };
}