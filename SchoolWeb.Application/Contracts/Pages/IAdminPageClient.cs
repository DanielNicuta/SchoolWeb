namespace SchoolWeb.Application.Contracts.Pages;

public interface IAdminPageClient
{
    Task<ApiResult<HomePageResponseDto>> UpdateHomeAsync(HomePageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<ContactPageResponseDto>> UpdateContactAsync(ContactPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<HistoryPageResponseDto>> UpdateHistoryAsync(HistoryPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<MissionPageResponseDto>> UpdateMissionAsync(MissionPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<OrganizationPageResponseDto>> UpdateOrganizationAsync(OrganizationPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<LinksPageResponseDto>> UpdateLinksAsync(LinksPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<FooterContentResponseDto>> UpdateFooterAsync(FooterContentUpdateDto dto, CancellationToken ct);
    Task<ApiResult<SiteSettingsResponseDto>> UpdateSiteSettingsAsync(SiteSettingsUpdateDto dto, CancellationToken ct);
}