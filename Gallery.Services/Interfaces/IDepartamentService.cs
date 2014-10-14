using System.Collections.Generic;
using Gallety.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IDepartamentService
    {
        IEnumerable<DbDepartament> GetDepartaments();
        DbDepartament GetDepartamentById(long id);
        void CreateDepartament(DbDepartament departament);
        void UpdateDepartament(DbDepartament departament);
        void DeleteDepartament(long id);
        void SaveDepartament();
    }
}
