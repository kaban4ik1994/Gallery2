using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallety.Entities;

namespace Gallery.Data.EntityRepositories.Concrete
{
    public class DescriptionRepository : EntityRepositoryBase<DbDescription>, IDescriptionRepository
    {
        public DescriptionRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}

