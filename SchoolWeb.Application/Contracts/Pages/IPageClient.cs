namespace SchoolWeb.Application.Contracts.Pages;

public interface IPageClient
{
    Task<ApiResult<HomePageResponseDto>> GetHomeAsync(CancellationToken ct);
    Task<ApiResult<ContactPageResponseDto>> GetContactAsync(CancellationToken ct);
    Task<ApiResult<HistoryPageResponseDto>> GetHistoryAsync(CancellationToken ct);
    Task<ApiResult<MissionPageResponseDto>> GetMissionAsync(CancellationToken ct);
    Task<ApiResult<OrganizationPageResponseDto>> GetOrganizationAsync(CancellationToken ct);
    Task<ApiResult<LinksPageResponseDto>> GetLinksAsync(CancellationToken ct);
    Task<ApiResult<FooterContentResponseDto>> GetFooterAsync(CancellationToken ct);
    Task<ApiResult<SiteSettingsResponseDto>> GetSiteSettingsAsync(CancellationToken ct);
}