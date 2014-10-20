using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallety.Entities;

namespace Gallery.Data.EntityRepositories.Concrete
{
    public class TokenRepository : EntityRepositoryBase<DbToken>, ITokenRepository
    {
        public TokenRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
