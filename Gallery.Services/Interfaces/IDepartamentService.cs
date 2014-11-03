using System.Collections.Generic;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IDepartamentService
    {
        IEnumerable<DbDepartament> GetDepartaments();
        DbDepartament GetDepartamentById(long id);
        DbDepartament GetDepartamentByName(string name);
        void CreateDepartament(DbDepartament departament);
        void UpdateDepartament(DbDepartament departament);
        void DeleteDepartament(long id);
        void SaveDepartament();
    }
}
