
using System.Collections.Generic;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IImageService
    {
        IEnumerable<DbImage> GetImages();
        DbImage GetImageById(long id);
        void CreateImage(DbImage image);
        void UpdateImage(DbImage image);
        void DeleteImage(long id);
        void SaveImage();
        DbImage GetImageByPictureId(long id, int minHeight, int minWidth, int maxHeight, int maxWidth);
    }
}
