using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Entities;

namespace Gallery.Data.EntityRepositories.Concrete
{
    public class DepartamentRepository : EntityRepositoryBase<DbDepartament>, IDepartamentRepository
    {
        public DepartamentRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
