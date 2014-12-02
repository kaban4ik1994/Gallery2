using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IImageUtil : IUtil
    {
        Image GetPictureImageData(long id, int minHeight,
            int minWidth, int maxHeight, int maxWidth);
    }
}
