using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gallery.Models.Models;

namespace Gallery.WebUI.Helpers
{
    public static class ImageHelper
    {
        public static Image FilterImagesByMaxHeightAndMaxWidth(IEnumerable<Image> images, int maxHeight,
            int maxWidth)
        {
            var image = images.FirstOrDefault(x => x.ImageHeight < maxHeight && x.ImageWidth < maxWidth);
            return image;
        }
    }
}