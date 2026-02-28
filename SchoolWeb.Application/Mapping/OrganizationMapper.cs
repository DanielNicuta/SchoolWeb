using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class OrganizationMapper : IMapper<OrganizationPageResponseDto, OrganizationPageUpdateDto>
{
    public OrganizationPageUpdateDto Map(OrganizationPageResponseDto src) => new()
    {
        Title = src.Title,
        DescriptionHtml = src.DescriptionHtml,
        OrgChartImageUrl = src.OrgChartImageUrl,
        OrgChartFileUrl = src.OrgChartFileUrl,
        SeoTitle = src.SeoTitle,
        SeoDescription = src.SeoDescription,
        OgImageUrl = src.OgImageUrl
    };
}