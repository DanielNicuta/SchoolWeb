using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Services.Pages;

public interface IPageEditorService
{
    Task<ApiResult<HomePageUpdateDto>> GetHomeEditorAsync(CancellationToken ct);
    Task<ApiResult<FooterContentUpdateDto>> GetFooterEditorAsync(CancellationToken ct);
    Task<ApiResult<SiteSettingsUpdateDto>> GetSiteSettingsEditorAsync(CancellationToken ct);
    Task<ApiResult<ContactPageUpdateDto>> GetContactEditorAsync(CancellationToken ct);
    Task<ApiResult<HistoryPageUpdateDto>> GetHistoryEditorAsync(CancellationToken ct);
    Task<ApiResult<MissionPageUpdateDto>> GetMissionEditorAsync(CancellationToken ct);
    Task<ApiResult<OrganizationPageUpdateDto>> GetOrganizationEditorAsync(CancellationToken ct);
    Task<ApiResult<LinksPageUpdateDto>> GetLinksEditorAsync(CancellationToken ct);



    Task<ApiResult<HomePageResponseDto>> UpdateHomeAsync(HomePageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<FooterContentResponseDto>> UpdateFooterAsync(FooterContentUpdateDto dto, CancellationToken ct);
    Task<ApiResult<SiteSettingsResponseDto>> UpdateSiteSettingsAsync(SiteSettingsUpdateDto dto, CancellationToken ct);
    Task<ApiResult<ContactPageResponseDto>> UpdateContactAsync(ContactPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<HistoryPageResponseDto>> UpdateHistoryAsync(HistoryPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<MissionPageResponseDto>> UpdateMissionAsync(MissionPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<OrganizationPageResponseDto>> UpdateOrganizationAsync(OrganizationPageUpdateDto dto, CancellationToken ct);
    Task<ApiResult<LinksPageResponseDto>> UpdateLinksAsync(LinksPageUpdateDto dto, CancellationToken ct);
}