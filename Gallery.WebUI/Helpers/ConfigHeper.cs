﻿using System.Configuration;

namespace Gallery.WebUI.Helpers
{
    public static class ConfigHeper
    {
        public static string AccountApiUrl { get { return ConfigurationManager.AppSettings["AccountApiUrl"]; } }
        public static string DepartamentApiUrl { get { return ConfigurationManager.AppSettings["DepartamentApiUrl"]; } }
        public static string GenreApiUrl { get { return ConfigurationManager.AppSettings["GenreApiUrl"]; } }
        public static string PainterApiUrl { get { return ConfigurationManager.AppSettings["PainterApiUrl"]; } }
        public static string PictureApiUrl { get { return ConfigurationManager.AppSettings["PictureApiUrl"]; } }
        public static string ImageApiUrl { get { return ConfigurationManager.AppSettings["ImageApiUrl"]; } }
        public static string CommentApiUrl { get { return ConfigurationManager.AppSettings["CommentApiUrl"]; } }
    }
}