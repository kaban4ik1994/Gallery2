using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallety.Entities;

namespace Gallery.Data.EntityRepositories.Concrete
{
    public class ImageRepository : EntityRepositoryBase<DbImage>, IImageRepository
    {
        public ImageRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
