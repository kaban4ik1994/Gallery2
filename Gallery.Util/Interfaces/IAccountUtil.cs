using System.Net;
using Gallery.Models.Models;
using Microsoft.Win32;

namespace Gallery.Util.Interfaces
{
    public interface IAccountUtil : IUtil
    {
        User GetUserByEmailAndPasswordHash(string email, string passwordHash);
        HttpStatusCode Registration(User user);
    }
}
