using SchoolWeb.Application.Contracts;

namespace SchoolWeb.Application.Contracts.Auth;

public interface IAuthClient
{
    Task<ApiResult<AuthTokensDto>> LoginAsync(LoginRequest request, CancellationToken ct);
    Task<ApiResult<AuthTokensDto>> RefreshAsync(RefreshRequest request, CancellationToken ct);

    // Optional (we’ll wire later): revoke/logout/logout-all/register
}
