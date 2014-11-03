using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Gallery.Security
{
    public static class SecurityHelper
    {
        public static string Hash(string s)
        {
            var bytes = Encoding.Unicode.GetBytes(s);
            var csp = new MD5CryptoServiceProvider();
            var byteHash = csp.ComputeHash(bytes);
            return byteHash.Aggregate(string.Empty, (current, b) => current + string.Format("{0:x2}", b));
        }
    }
}
