using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Infrastructure.Http;

public sealed class PageClient : IPageClient
{
    private readonly IApiClient _api;

    public PageClient(IApiClient api) => _api = api;

    public Task<ApiResult<HomePageResponseDto>> GetHomeAsync(CancellationToken ct) =>
        _api.GetAsync<HomePageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Home), ct);

    public Task<ApiResult<ContactPageResponseDto>> GetContactAsync(CancellationToken ct) =>
        _api.GetAsync<ContactPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Contact), ct);

    public Task<ApiResult<HistoryPageResponseDto>> GetHistoryAsync(CancellationToken ct) =>
        _api.GetAsync<HistoryPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.History), ct);

    public Task<ApiResult<MissionPageResponseDto>> GetMissionAsync(CancellationToken ct) =>
        _api.GetAsync<MissionPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Mission), ct);

    public Task<ApiResult<OrganizationPageResponseDto>> GetOrganizationAsync(CancellationToken ct) =>
        _api.GetAsync<OrganizationPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Organization), ct);

    public Task<ApiResult<LinksPageResponseDto>> GetLinksAsync(CancellationToken ct) =>
        _api.GetAsync<LinksPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Links), ct);

    public Task<ApiResult<FooterContentResponseDto>> GetFooterAsync(CancellationToken ct) =>
        _api.GetAsync<FooterContentResponseDto>(ApiRoutes.Pages.ByName(PageNames.Footer), ct);

    public Task<ApiResult<SiteSettingsResponseDto>> GetSiteSettingsAsync(CancellationToken ct) =>
        _api.GetAsync<SiteSettingsResponseDto>(ApiRoutes.Pages.ByName(PageNames.Settings), ct);
}