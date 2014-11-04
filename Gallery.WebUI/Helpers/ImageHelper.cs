using System.Collections.Generic;
using System.Linq;
using Gallery.Models.Models;

namespace Gallery.WebUI.Helpers
{
    public static class ImageHelper
    {
        public static Image FilterImagesByMaxHeightAndMaxWidth(List<Image> images, int minHeight,
            int minWidth, int maxHeight, int maxWidth)
        {
            var image = images.FirstOrDefault(x => x.ImageHeight >= minHeight && x.ImageHeight <= maxHeight && x.ImageWidth >= minWidth && x.ImageWidth <= maxWidth);
            return image;
        }
    }
}