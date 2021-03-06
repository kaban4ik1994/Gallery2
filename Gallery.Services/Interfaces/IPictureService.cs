﻿using System.Collections.Generic;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IPictureService
    {
        IEnumerable<DbPicture> GetPictures();
        DbPicture GetPictureById(long id);
        DbPicture GetPictureByName(string name);
        void CreatePicture(DbPicture picture);
        void UpdatePicture(DbPicture picture);
        void DeletePicture(long id);
        void SavePicture();
    }
}
