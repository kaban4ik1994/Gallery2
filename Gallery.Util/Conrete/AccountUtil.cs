using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Gallery.Models.Models;
using Gallery.Util.Helpers;
using Gallery.Util.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gallery.Util.Conrete
{
    public class AccountUtil : IAccountUtil
    {
        public string ApiUrl { get; private set; }

        public AccountUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public User GetUserByEmail(string email)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "email", email } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<User>(JObject.Parse(result.Content.ReadAsStringAsync().Result).ToString()) : null;
            }
        }

        public User GetUserByEmailAndPasswordHash(string email, string passwordHash)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "email", email }, { "passwordHash", passwordHash } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<User>(JObject.Parse(result.Content.ReadAsStringAsync().Result).ToString()) : null;
            }
        }

        public User Registration(User user)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PutAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<User>(JObject.Parse(result.Content.ReadAsStringAsync().Result).ToString()) : null;
            }
        }

        public User UpdateUser(User user)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<User>(JObject.Parse(result.Content.ReadAsStringAsync().Result).ToString()) : null;
            }
        }

        public HttpStatusCode DeleteUser(long id)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.DeleteAsync(RequestHelper.GenerateRequestUrl(ApiUrl, new Dictionary<string, object> { { "id", id } })).Result;
                return result.StatusCode;
            }
        }
    }
}
