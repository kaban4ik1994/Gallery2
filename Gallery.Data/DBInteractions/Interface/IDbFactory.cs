using System;

namespace Gallery.Data.DBInteractions.Interface
{
    public interface IDbFactory : IDisposable
    {
        GalleryContext Get();
    }
}
