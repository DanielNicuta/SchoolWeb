namespace SchoolWeb.Application.Shared;

public static class ApiRoutes
{
    public static class Pages
    {
        private const string Base = "/api/page";
        public static string ByName(string name) => $"{Base}/{name}";
    }

    public static class Teachers
    {
        public const string Base = "/api/teachers";
        public static string ById(int id) => $"{Base}/{id}";
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
