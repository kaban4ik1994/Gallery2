using Gallery.ServicesAPI.Interfaces;

namespace Gallery.ServicesAPI.Conrete
{
    public class AccountService : IAccountService
    {
        public string ApiUrl { get; private set; }

        public AccountService(string apiUrl)
        {
            ApiUrl = apiUrl;
        }
    }
}
