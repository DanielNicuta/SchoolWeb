namespace SchoolWeb.Infrastructure.Auth;

public interface ITokenStore
{
    Task<TokenPair?> GetAsync();
    Task SetAsync(TokenPair tokens);
    Task ClearAsync();
}
