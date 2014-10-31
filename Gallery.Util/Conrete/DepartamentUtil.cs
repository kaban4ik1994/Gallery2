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
    public class DepartamentUtil : IDepartamentUtil
    {
        public string ApiUrl { get; private set; }

        public DepartamentUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public Departament GetDepartamentById(long id)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "id", id } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Departament>(JObject.Parse(result.Content.ReadAsStringAsync().Result).ToString()) : null;
            }
        }

        public Departament CreateDepartament(Departament departament)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PutAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(departament), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Departament>(JObject.Parse(result.Content.ReadAsStringAsync().Result).ToString()) : null;
            }
        }

        public Departament UpdateDepartament(Departament departament)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(departament), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Departament>(JObject.Parse(result.Content.ReadAsStringAsync().Result).ToString()) : null;
            }
        }

        public HttpStatusCode DeleteDepartament(long id)
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
