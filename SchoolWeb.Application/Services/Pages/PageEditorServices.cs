using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Mapping;

namespace SchoolWeb.Application.Services.Pages;

public sealed class PageEditorService : IPageEditorService
{
    private readonly IPageClient _pages;
    private readonly IAdminPageClient _admin;

    private readonly IMapper<HomePageResponseDto, HomePageUpdateDto> _homeMapper;
    private readonly IMapper<FooterContentResponseDto, FooterContentUpdateDto> _footerMapper;
    private readonly IMapper<SiteSettingsResponseDto, SiteSettingsUpdateDto> _settingsMapper;
    private readonly IMapper<ContactPageResponseDto, ContactPageUpdateDto> _contactMapper;
    private readonly IMapper<HistoryPageResponseDto, HistoryPageUpdateDto> _historyMapper;
    private readonly IMapper<MissionPageResponseDto, MissionPageUpdateDto> _missionMapper;
    private readonly IMapper<OrganizationPageResponseDto, OrganizationPageUpdateDto> _orgMapper;
    private readonly IMapper<LinksPageResponseDto, LinksPageUpdateDto> _linksMapper;

    public PageEditorService(
        IPageClient pages,
        IAdminPageClient admin,
        IMapper<HomePageResponseDto, HomePageUpdateDto> homeMapper,
        IMapper<FooterContentResponseDto, FooterContentUpdateDto> footerMapper,
        IMapper<SiteSettingsResponseDto, SiteSettingsUpdateDto> settingsMapper,
        IMapper<ContactPageResponseDto, ContactPageUpdateDto> contactMapper,
        IMapper<HistoryPageResponseDto, HistoryPageUpdateDto> historyMapper,
        IMapper<MissionPageResponseDto, MissionPageUpdateDto> missionMapper,
        IMapper<OrganizationPageResponseDto, OrganizationPageUpdateDto> orgMapper,
        IMapper<LinksPageResponseDto, LinksPageUpdateDto> linksMapper)
        
    {
        _pages = pages;
        _admin = admin;
        _homeMapper = homeMapper;
        _footerMapper = footerMapper;
        _settingsMapper = settingsMapper;
        _contactMapper = contactMapper;
        _historyMapper = historyMapper;
        _missionMapper = missionMapper;
        _orgMapper = orgMapper;
        _linksMapper = linksMapper;

    }

    public async Task<ApiResult<HomePageUpdateDto>> GetHomeEditorAsync(CancellationToken ct)
    {
        var result = await _pages.GetHomeAsync(ct);
        if (!result.IsSuccess || result.Data is null) return ApiResult<HomePageUpdateDto>.Fail(result.Message, result.Errors);
        return ApiResult<HomePageUpdateDto>.Ok(_homeMapper.Map(result.Data));
    }

    public async Task<ApiResult<FooterContentUpdateDto>> GetFooterEditorAsync(CancellationToken ct)
    {
        var result = await _pages.GetFooterAsync(ct);
        if (!result.IsSuccess || result.Data is null) return ApiResult<FooterContentUpdateDto>.Fail(result.Message, result.Errors);
        return ApiResult<FooterContentUpdateDto>.Ok(_footerMapper.Map(result.Data));
    }

    public async Task<ApiResult<SiteSettingsUpdateDto>> GetSiteSettingsEditorAsync(CancellationToken ct)
    {
        var result = await _pages.GetSiteSettingsAsync(ct);
        if (!result.IsSuccess || result.Data is null) return ApiResult<SiteSettingsUpdateDto>.Fail(result.Message, result.Errors);
        return ApiResult<SiteSettingsUpdateDto>.Ok(_settingsMapper.Map(result.Data));
    }

    public async Task<ApiResult<ContactPageUpdateDto>> GetContactEditorAsync(CancellationToken ct)
    {
        var result = await _pages.GetContactAsync(ct);
        if (!result.IsSuccess || result.Data is null) return ApiResult<ContactPageUpdateDto>.Fail(result.Message, result.Errors);
        return ApiResult<ContactPageUpdateDto>.Ok(_contactMapper.Map(result.Data));
    }
    public async Task<ApiResult<HistoryPageUpdateDto>> GetHistoryEditorAsync(CancellationToken ct)
    {
        var r = await _pages.GetHistoryAsync(ct);
        if (!r.IsSuccess || r.Data is null) return ApiResult<HistoryPageUpdateDto>.Fail(r.Message, r.Errors);
        return ApiResult<HistoryPageUpdateDto>.Ok(_historyMapper.Map(r.Data));
    }

    public async Task<ApiResult<MissionPageUpdateDto>> GetMissionEditorAsync(CancellationToken ct)
    {
        var r = await _pages.GetMissionAsync(ct);
        if (!r.IsSuccess || r.Data is null) return ApiResult<MissionPageUpdateDto>.Fail(r.Message, r.Errors);
        return ApiResult<MissionPageUpdateDto>.Ok(_missionMapper.Map(r.Data));
    }

    public async Task<ApiResult<OrganizationPageUpdateDto>> GetOrganizationEditorAsync(CancellationToken ct)
    {
        var r = await _pages.GetOrganizationAsync(ct);
        if (!r.IsSuccess || r.Data is null) return ApiResult<OrganizationPageUpdateDto>.Fail(r.Message, r.Errors);
        return ApiResult<OrganizationPageUpdateDto>.Ok(_orgMapper.Map(r.Data));
    }

    public async Task<ApiResult<LinksPageUpdateDto>> GetLinksEditorAsync(CancellationToken ct)
    {
        var r = await _pages.GetLinksAsync(ct);
        if (!r.IsSuccess || r.Data is null) return ApiResult<LinksPageUpdateDto>.Fail(r.Message, r.Errors);
        return ApiResult<LinksPageUpdateDto>.Ok(_linksMapper.Map(r.Data));
    }

    public Task<ApiResult<HomePageResponseDto>> UpdateHomeAsync(HomePageUpdateDto dto, CancellationToken ct) =>
        _admin.UpdateHomeAsync(dto, ct);

    public Task<ApiResult<FooterContentResponseDto>> UpdateFooterAsync(FooterContentUpdateDto dto, CancellationToken ct) =>
        _admin.UpdateFooterAsync(dto, ct);

    public Task<ApiResult<SiteSettingsResponseDto>> UpdateSiteSettingsAsync(SiteSettingsUpdateDto dto, CancellationToken ct) =>
        _admin.UpdateSiteSettingsAsync(dto, ct);

    public Task<ApiResult<ContactPageResponseDto>> UpdateContactAsync(ContactPageUpdateDto dto, CancellationToken ct) =>
        _admin.UpdateContactAsync(dto, ct);
    
    public Task<ApiResult<HistoryPageResponseDto>> UpdateHistoryAsync(HistoryPageUpdateDto dto, CancellationToken ct)
        => _admin.UpdateHistoryAsync(dto, ct);

    public Task<ApiResult<MissionPageResponseDto>> UpdateMissionAsync(MissionPageUpdateDto dto, CancellationToken ct)
        => _admin.UpdateMissionAsync(dto, ct);

    public Task<ApiResult<OrganizationPageResponseDto>> UpdateOrganizationAsync(OrganizationPageUpdateDto dto, CancellationToken ct)
        => _admin.UpdateOrganizationAsync(dto, ct);

    public Task<ApiResult<LinksPageResponseDto>> UpdateLinksAsync(LinksPageUpdateDto dto, CancellationToken ct)
        => _admin.UpdateLinksAsync(dto, ct);
}