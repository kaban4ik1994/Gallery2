using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallety.Entities;

namespace Gallery.Data.EntityRepositories.Concrete
{
    public class RoleRepository : EntityRepositoryBase<DbRole>, IRoleRepository
    {
        public RoleRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
