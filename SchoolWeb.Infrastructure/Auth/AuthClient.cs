using SchoolWeb.Application.Contracts;
using SchoolWeb.Application.Contracts.Auth;
using SchoolWeb.Application.Shared;
using SchoolWeb.Infrastructure.Http;

namespace SchoolWeb.Infrastructure.Auth;

public sealed class AuthClient : IAuthClient
{
    private readonly IApiClient _api;

    public AuthClient(IApiClient api) => _api = api;

    public Task<ApiResult<AuthTokensDto>> LoginAsync(LoginRequest request, CancellationToken ct) =>
        _api.PostAsync<LoginRequest, AuthTokensDto>(ApiRoutes.Auth.Login, request, ct);

    public Task<ApiResult<AuthTokensDto>> RefreshAsync(RefreshRequest request, CancellationToken ct) =>
        _api.PostAsync<RefreshRequest, AuthTokensDto>(ApiRoutes.Auth.Refresh, request, ct);
}
