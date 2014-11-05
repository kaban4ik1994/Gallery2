using System.Collections.Generic;
using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IPictureUtil
    {
        IEnumerable<Picture> GetPicturess();
        Picture GetPictureById(long id);
        Picture GetPictureByName(string name);
        Picture CreatePicture(Picture picture);
        Picture UpdatePicture(Picture picture);
        HttpStatusCode DeletePicture(long id);
    }
}
