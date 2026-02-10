using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Infrastructure.Http;

public sealed class PageClient : IPageClient
{
    private readonly IApiClient _api;

    public PageClient(IApiClient api) => _api = api;

    public Task<ApiResult<CmsPageDto>> GetPageAsync(string pageName, CancellationToken ct) =>
        _api.GetAsync<CmsPageDto>(ApiRoutes.Pages.ByName(pageName), ct);
}
