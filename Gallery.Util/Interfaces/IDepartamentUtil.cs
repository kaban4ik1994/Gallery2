using System.Collections.Generic;
using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IDepartamentUtil : IUtil
    {
        IEnumerable<Departament> GetDepartaments();
        Departament GetDepartamentById(long id);
        Departament GetDepartamentByName(string name);
        Departament CreateDepartament(Departament departament);
        Departament UpdateDepartament(Departament departament);
        HttpStatusCode DeleteDepartament(long id);
    }
}
