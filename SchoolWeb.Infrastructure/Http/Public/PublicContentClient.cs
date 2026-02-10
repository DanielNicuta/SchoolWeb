using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Public;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Infrastructure.Http;

public sealed class PublicContentClient : IPublicContentClient
{
    private readonly IApiClient _api;

    public PublicContentClient(IApiClient api) => _api = api;

    public Task<ApiResult<HomeDto>> GetHomeAsync(CancellationToken ct) =>
        _api.GetAsync<HomeDto>(ApiRoutes.Pages.Home, ct);

    public Task<ApiResult<ContactPageDto>> GetContactAsync(CancellationToken ct) =>
        _api.GetAsync<ContactPageDto>(ApiRoutes.Pages.Contact, ct);

    public Task<ApiResult<HistoryPageDto>> GetHistoryAsync(CancellationToken ct) =>
        _api.GetAsync<HistoryPageDto>(ApiRoutes.Pages.History, ct);

    public Task<ApiResult<MissionPageDto>> GetMissionAsync(CancellationToken ct) =>
        _api.GetAsync<MissionPageDto>(ApiRoutes.Pages.Mission, ct);

    public Task<ApiResult<OrganizationPageDto>> GetOrganizationAsync(CancellationToken ct) =>
        _api.GetAsync<OrganizationPageDto>(ApiRoutes.Pages.Organization, ct);

    public Task<ApiResult<LinksPageDto>> GetLinksAsync(CancellationToken ct) =>
        _api.GetAsync<LinksPageDto>(ApiRoutes.Pages.Links, ct);

    public Task<ApiResult<FooterPageDto>> GetFooterAsync(CancellationToken ct) =>
        _api.GetAsync<FooterPageDto>(ApiRoutes.Pages.Footer, ct);

    public Task<ApiResult<SiteSettingsDto>> GetSiteSettingsAsync(CancellationToken ct) =>
        _api.GetAsync<SiteSettingsDto>(ApiRoutes.Pages.SiteSettings, ct);
}
