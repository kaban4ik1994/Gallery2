using System.Collections.Generic;
using Gallety.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<DbRole> GetRoles();
        DbRole GetRoleById(long id);
        void CreateRole(DbRole role);
        void UpdateRole(DbRole role);
        void DeleteRole(long id);
        void SaveRole();
    }
}
