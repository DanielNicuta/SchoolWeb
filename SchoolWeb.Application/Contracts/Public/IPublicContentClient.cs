using SchoolWeb.Application.Contracts;

namespace SchoolWeb.Application.Contracts.Public;

public interface IPublicContentClient
{
    Task<ApiResult<HomeDto>> GetHomeAsync(CancellationToken ct);
    Task<ApiResult<ContactPageDto>> GetContactAsync(CancellationToken ct);
    Task<ApiResult<HistoryPageDto>> GetHistoryAsync(CancellationToken ct);
    Task<ApiResult<MissionPageDto>> GetMissionAsync(CancellationToken ct);
    Task<ApiResult<OrganizationPageDto>> GetOrganizationAsync(CancellationToken ct);
    Task<ApiResult<LinksPageDto>> GetLinksAsync(CancellationToken ct);
    Task<ApiResult<FooterPageDto>> GetFooterAsync(CancellationToken ct);
    Task<ApiResult<SiteSettingsDto>> GetSiteSettingsAsync(CancellationToken ct);
}
