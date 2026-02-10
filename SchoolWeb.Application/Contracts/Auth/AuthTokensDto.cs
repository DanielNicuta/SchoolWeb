namespace SchoolWeb.Application.Contracts.Auth;

public sealed class AuthTokensDto
{
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
}
