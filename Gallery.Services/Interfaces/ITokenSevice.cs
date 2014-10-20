using System.Collections.Generic;
using Gallety.Entities;

namespace Gallery.Services.Interfaces
{
    public interface ITokenSevice
    {
        IEnumerable<DbToken> GetTokens();
        DbToken GetTokenById(long id);
        void CreateToken(DbToken token);
        void UpdateToken(DbToken token);
        void DeleteToken(long id);
        void SaveToken();
    }
}
