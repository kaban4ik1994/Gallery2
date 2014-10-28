using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;

namespace Gallery.Data.EntityRepositories.Concrete
{
    public class UserRepository : EntityRepositoryBase<DbUser>, IUserRepository
    {
        public UserRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
