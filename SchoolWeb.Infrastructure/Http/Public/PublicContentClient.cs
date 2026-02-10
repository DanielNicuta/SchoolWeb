using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Public;
using SchoolWeb.Application.Shared;

namespace SchoolWeb.Infrastructure.Http;

public sealed class PublicContentClient : IPublicContentClient
{
    private readonly IApiClient _api;

    public PublicContentClient(IApiClient api) => _api = api;

    public Task<ApiResult<HomeDto>> GetHomeAsync(CancellationToken ct) =>
        _api.GetAsync<HomeDto>(ApiRoutes.Public.Home, ct);
}
