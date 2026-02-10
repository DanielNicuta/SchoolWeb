using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Public;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Infrastructure.Http;

public sealed class PublicContentClient : IPublicContentClient
{
    private readonly IApiClient _api;

    public PublicContentClient(IApiClient api) => _api = api;

    public Task<ApiResult<HomeDto>> GetHomeAsync(CancellationToken ct) =>
        _api.GetAsync<HomeDto>(ApiRoutes.Pages.ByName(PageNames.Home), ct);

    public Task<ApiResult<ContactPageDto>> GetContactAsync(CancellationToken ct) =>
        _api.GetAsync<ContactPageDto>(ApiRoutes.Pages.ByName(PageNames.Contact), ct);

    public Task<ApiResult<HistoryPageDto>> GetHistoryAsync(CancellationToken ct) =>
        _api.GetAsync<HistoryPageDto>(ApiRoutes.Pages.ByName(PageNames.History), ct);

    public Task<ApiResult<MissionPageDto>> GetMissionAsync(CancellationToken ct) =>
        _api.GetAsync<MissionPageDto>(ApiRoutes.Pages.ByName(PageNames.Mission), ct);

    public Task<ApiResult<OrganizationPageDto>> GetOrganizationAsync(CancellationToken ct) =>
        _api.GetAsync<OrganizationPageDto>(ApiRoutes.Pages.ByName(PageNames.Organization), ct);

    public Task<ApiResult<LinksPageDto>> GetLinksAsync(CancellationToken ct) =>
        _api.GetAsync<LinksPageDto>(ApiRoutes.Pages.ByName(PageNames.Links), ct);

    public Task<ApiResult<FooterPageDto>> GetFooterAsync(CancellationToken ct) =>
        _api.GetAsync<FooterPageDto>(ApiRoutes.Pages.ByName(PageNames.Footer), ct);

    public Task<ApiResult<SiteSettingsDto>> GetSiteSettingsAsync(CancellationToken ct) =>
        _api.GetAsync<SiteSettingsDto>(ApiRoutes.Pages.ByName(PageNames.Settings), ct);
}
