using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;

namespace Gallery.Data.EntityRepositories.Concrete
{
    public class PictureRepository : EntityRepositoryBase<DbPicture>, IPictureRepository
    {
        public PictureRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
