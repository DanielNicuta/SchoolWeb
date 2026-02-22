using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Infrastructure.Http;

public sealed class AdminPageClient : IAdminPageClient
{
    private readonly IAdminApiClient _adminApi;

    public AdminPageClient(IAdminApiClient adminApi) => _adminApi = adminApi;

    public Task<ApiResult<HomePageResponseDto>> UpdateHomeAsync(HomePageUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<HomePageUpdateDto, HomePageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Home), dto, ct);

    public Task<ApiResult<ContactPageResponseDto>> UpdateContactAsync(ContactPageUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<ContactPageUpdateDto, ContactPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Contact), dto, ct);

    public Task<ApiResult<HistoryPageResponseDto>> UpdateHistoryAsync(HistoryPageUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<HistoryPageUpdateDto, HistoryPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.History), dto, ct);

    public Task<ApiResult<MissionPageResponseDto>> UpdateMissionAsync(MissionPageUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<MissionPageUpdateDto, MissionPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Mission), dto, ct);

    public Task<ApiResult<OrganizationPageResponseDto>> UpdateOrganizationAsync(OrganizationPageUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<OrganizationPageUpdateDto, OrganizationPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Organization), dto, ct);

    public Task<ApiResult<LinksPageResponseDto>> UpdateLinksAsync(LinksPageUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<LinksPageUpdateDto, LinksPageResponseDto>(ApiRoutes.Pages.ByName(PageNames.Links), dto, ct);

    public Task<ApiResult<FooterContentResponseDto>> UpdateFooterAsync(FooterContentUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<FooterContentUpdateDto, FooterContentResponseDto>(ApiRoutes.Pages.ByName(PageNames.Footer), dto, ct);

    public Task<ApiResult<SiteSettingsResponseDto>> UpdateSiteSettingsAsync(SiteSettingsUpdateDto dto, CancellationToken ct) =>
        _adminApi.PutAsync<SiteSettingsUpdateDto, SiteSettingsResponseDto>(ApiRoutes.Pages.ByName(PageNames.Settings), dto, ct);
}