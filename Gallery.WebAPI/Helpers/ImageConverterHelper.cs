using System.Linq;
using Gallery.Models.Models;

namespace Gallery.WebAPI.Helpers
{
    public static class ImageConverterHelper
    {
        public static Image ResizeImage(Image image,  string nFileName, string imageExtension, int nWidth, int nHeight)
        {
            var bytes = ImageConverter.ImageConverter.ResizeImage(image.ImageData, nWidth, nHeight);
            var result = new Image
            {
                ImageData = bytes,
                ImageExtension = imageExtension,
                ImageHeight = nHeight,
                ImageWidth = nWidth,
                ImageName = nFileName
            };
            return result;
        }
    }
}