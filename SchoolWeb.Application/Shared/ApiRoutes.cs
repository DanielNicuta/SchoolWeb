namespace SchoolWeb.Application.Shared;

/// <summary>
/// Central place for API endpoints. No “stringly-typed” URLs scattered around.
/// </summary>
public static class ApiRoutes
{
    public static class Public
    {
        public const string Home = "/api/public/home";
        // Add others next: About, Contact, Teachers, etc. based on API README
    }

    public static class Auth
    {
        public const string Login = "/api/auth/login";
        public const string Refresh = "/api/auth/refresh";
        public const string Logout = "/api/auth/logout";
    }

    public static class Admin
    {
        public const string Home = "/api/admin/home";
        // Add others next
    }
}
