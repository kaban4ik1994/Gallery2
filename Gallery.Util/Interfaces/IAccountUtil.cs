using System.Net;
using Gallery.Models.Models;

namespace Gallery.Util.Interfaces
{
    public interface IAccountUtil : IUtil
    {
        User GetUserByEmail(string email);
        User GetUserByEmailAndPasswordHash(string email, string passwordHash);
        User Registration(User user);
        User UpdateUser(User user);
        HttpStatusCode DeleteUser(long id);
    }
}
