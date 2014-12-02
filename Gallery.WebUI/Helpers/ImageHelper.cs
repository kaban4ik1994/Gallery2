using Gallery.Models.Models;
using Gallery.Util.Interfaces;

namespace Gallery.WebUI.Helpers
{
    public static class ImageHelper
    {
        public static Image FilterImagesByMaxHeightAndMaxWidth(IImageUtil imageUtil,long id, int minHeight,
            int minWidth, int maxHeight, int maxWidth)
        {
            var image = imageUtil.GetPictureImageData(id, minHeight, minWidth, maxHeight, maxWidth);
            return image;
        }
    }
}