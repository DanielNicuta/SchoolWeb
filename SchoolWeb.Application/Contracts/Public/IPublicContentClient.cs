using SchoolWeb.Application.Contracts;

namespace SchoolWeb.Application.Contracts.Public;

public interface IPublicContentClient
{
    Task<ApiResult<HomeDto>> GetHomeAsync(CancellationToken ct);
}
