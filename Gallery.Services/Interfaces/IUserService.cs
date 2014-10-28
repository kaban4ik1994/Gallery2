using System.Collections.Generic;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<DbUser> GetUsers();
        DbUser GetUserById(long id);
        DbUser GetUserByEmail(string email);
        DbUser GetUserByEmailAndPasswordHash(string email, string passwordHash);
        void CreateUser(DbUser user);
        void UpdateUser(DbUser user);
        void DeleteUser(long id);
        void SaveUser();
    }
}
