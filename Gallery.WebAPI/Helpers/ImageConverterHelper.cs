using System.Linq;
using Gallery.Models.Models;

namespace Gallery.WebAPI.Helpers
{
    public static class ImageConverterHelper
    {
        public static Image ResizeImage(Image image,  string nFileName, string imageExtension, int nWidth, int nHeight)
        {
            var nImage = ImageConverter.ImageConverter.ResizeImage(image.ImageData, nWidth, nHeight);
            var result = new Image
            {
                ImageData = ImageConverter.ImageConverter.ImageToByteArray(nImage),
                ImageExtension = imageExtension,
                ImageHeight = nImage.Height,
                ImageWidth = nImage.Width,
                ImageName = nFileName
            };
            return result;
        }
    }
}