using System.Collections.Generic;
using Gallety.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IPictureService
    {
        IEnumerable<DbPicture> GetPictures();
        DbPicture GetPictureById(long id);
        void CreatePicture(DbPainter painter);
        void UpdatePicture(DbPainter painter);
        void DeletePicture(long id);
        void SavePicture();
    }
}
