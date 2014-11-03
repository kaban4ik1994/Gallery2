using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Gallery.Models.Models;
using Gallery.Util.Helpers;
using Gallery.Util.Interfaces;
using Newtonsoft.Json;

namespace Gallery.Util.Conrete
{
    public class DepartamentUtil : IDepartamentUtil
    {
        public string ApiUrl { get; private set; }

        public DepartamentUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public IEnumerable<Departament> GetDepartaments()
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(ApiUrl).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<Departament>>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Departament GetDepartamentById(long id)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "id", id } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Departament>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Departament GetDepartamentByName(string name)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "name", name } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Departament>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Departament CreateDepartament(Departament departament)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PutAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(departament), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Departament>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Departament UpdateDepartament(Departament departament)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(departament), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Departament>(result.Content.ReadAsStringAsync().Result) : null;
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
