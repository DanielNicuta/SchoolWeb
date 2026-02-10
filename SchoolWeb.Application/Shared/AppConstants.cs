namespace SchoolWeb.Application.Shared;

public static class AppConstants
{
    public static class Areas
    {
        public const string Admin = "Admin";
    }

    public static class Routes
    {
        public const string DefaultController = "Home";
        public const string DefaultAction = "Index";
    }

    public static class CacheKeys
    {
        public const string SiteSettings = "cache:siteSettings";
        public const string Footer = "cache:footer";
    }
}
