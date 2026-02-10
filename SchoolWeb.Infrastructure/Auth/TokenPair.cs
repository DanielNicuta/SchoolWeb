namespace SchoolWeb.Infrastructure.Auth;

public sealed record TokenPair(string AccessToken, string RefreshToken);
