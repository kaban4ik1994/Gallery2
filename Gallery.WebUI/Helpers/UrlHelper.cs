using Gallery.Models.Models;

namespace Gallery.WebUI.Helpers
{
    public static class UrlHelper
    {
        public static string Image(this System.Web.Mvc.UrlHelper url,
    string actionName, string controllerName, Image image)
        {
            return url.Action(actionName, controllerName, new { imageId = image.ImageId});
        }
    }
}