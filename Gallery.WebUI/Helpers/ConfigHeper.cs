using System.Configuration;

namespace Gallery.WebUI.Helpers
{
    public static class ConfigHeper
    {
        public static string AccountApiUrl { get { return ConfigurationManager.AppSettings["AccountApiUrl"]; } }
        public static string DepartamentApiUrl { get { return ConfigurationManager.AppSettings["DepartamentApiUrl"]; } }
        public static string GenreApiUrl { get { return ConfigurationManager.AppSettings["GenreApiUrl"]; } }
        public static string PainterApiUrl { get { return ConfigurationManager.AppSettings["PainterApiUrl"]; } }
    }
}