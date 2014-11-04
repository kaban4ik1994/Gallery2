using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Gallery.ImageConverter
{
    public static class ImageConverter
    {
        public static byte[] ResizeImage(byte[] origFile, int nWidth, int nHeight)
        {
            var image = ByteArrayToImage(origFile);
            int newWidth, newHeight;
            var coefH = (double)nHeight / image.Height;
            var coefW = (double)nWidth / image.Width;
            if (coefW >= coefH)
            {
                newHeight = (int)(image.Height * coefH);
                newWidth = (int)(image.Width * coefH);
            }
            else
            {
                newHeight = (int)(image.Height * coefW);
                newWidth = (int)(image.Width * coefW);
            }
            Image result = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(result))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(image, 0, 0, newWidth, newHeight);
                g.Dispose();
            }
            return ImageToByteArray(result);
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn) { Position = 0 };
            var image = Image.FromStream(ms);
            return image;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            var imageExtension = GetImageFormat(image);
            var ms = new MemoryStream { Position = 0 };
            image.Save(ms, imageExtension);
            return ms.ToArray();
        }

        public static ImageFormat GetImageFormat(Image image)
        {
            var result = ImageFormat.Png;
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                result = ImageFormat.Jpeg;
            }
            if (ImageFormat.Bmp.Equals(image.RawFormat))
            {
                result = ImageFormat.Bmp;
            }
            if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                result = ImageFormat.Gif;
            }
            if (ImageFormat.Wmf.Equals(image.RawFormat))
            {
                result = ImageFormat.Wmf;
            }
            if (ImageFormat.Tiff.Equals(image.RawFormat))
            {
                result = ImageFormat.Tiff;
            }
            if (ImageFormat.Emf.Equals(image.RawFormat))
            {
                result = ImageFormat.Emf;
            }
            if (ImageFormat.Exif.Equals(image.RawFormat))
            {
                result = ImageFormat.Exif;
            }
            if (ImageFormat.Icon.Equals(image.RawFormat))
            {
                result = ImageFormat.Icon;
            }
            return result;
        }
    }
}
