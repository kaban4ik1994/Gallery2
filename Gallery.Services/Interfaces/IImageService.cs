
using System.Collections.Generic;
using Gallety.Entities;

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
    }
}
