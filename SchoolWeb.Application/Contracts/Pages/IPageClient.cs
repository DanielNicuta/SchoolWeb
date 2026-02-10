using SchoolWeb.Application.Contracts;

namespace SchoolWeb.Application.Contracts.Pages;

public interface IPageClient
{
    Task<ApiResult<CmsPageDto>> GetPageAsync(string pageName, CancellationToken ct);
}
