using System;

namespace Gallery.Data.DBInteractions
{
    public interface IDbFactory : IDisposable
    {
        GalleryContext Get();
    }
}
