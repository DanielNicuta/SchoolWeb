namespace SchoolWeb.Infrastructure.Http;

public sealed class AdminApiClient : ApiClient, IAdminApiClient
{
    public AdminApiClient(HttpClient http, Microsoft.Extensions.Logging.ILogger<ApiClient> logger)
        : base(http, logger)
    {
    }
}
