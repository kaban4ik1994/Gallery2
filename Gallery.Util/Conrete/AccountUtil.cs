using Gallery.Util.Interfaces;

namespace Gallery.Util.Conrete
{
    public class AccountUtil : IAccountUtil
    {
        public string ApiUrl { get; private set; }

        public AccountUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }
    }
}
