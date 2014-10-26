using System.Configuration;

namespace Gallery.WebUI.Helpers
{
    public static class ConfigHeper
    {
        public static string AccountApiUrl { get { return ConfigurationManager.AppSettings["AccountApiUrl"]; } }
    }
}