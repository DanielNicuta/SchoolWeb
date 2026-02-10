namespace SchoolWeb.Application.Shared;

/// <summary>
/// Central place for API endpoints. No stringly-typed URLs scattered around.
/// </summary>
public static class ApiRoutes
{
    public static class Pages
    {
        // CMS Pages (GET anonymous, PUT admin) — matches API routes: api/page/{pageName}
        public const string Home = "/api/page/home";
        public const string Contact = "/api/page/contact";
        public const string History = "/api/page/history";
        public const string Mission = "/api/page/mission";
        public const string Organization = "/api/page/organization";
        public const string Links = "/api/page/links";
        public const string Footer = "/api/page/footer";
        public const string SiteSettings = "/api/page/settings";
    }

    public static class Teachers
    {
        public const string Base = "/api/teachers";         // GET list, POST create
        public static string ById(int id) => $"/api/teachers/{id}";
    }

    public static class Auth
    {
        public const string Login = "/api/auth/login";
        public const string Refresh = "/api/auth/refresh";
        public const string Revoke = "/api/auth/revoke";
        public const string Logout = "/api/auth/logout";
        public const string LogoutAll = "/api/auth/logout-all";
        public const string Register = "/api/auth/register";
    }
}
