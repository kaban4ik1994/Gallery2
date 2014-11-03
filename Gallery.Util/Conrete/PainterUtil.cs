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
    public class PainterUtil : IPainterUtil
    {
        public string ApiUrl { get; private set; }

        public PainterUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public IEnumerable<Painter> GetPainters()
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(ApiUrl).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<Painter>>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Painter GetPainterById(long id)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "id", id } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Painter>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Painter GetPainterByName(string name)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "name", name } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Painter>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Painter CreatePainter(Painter painter)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PutAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(painter), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Painter>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Painter UpdatePainter(Painter painter)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(painter), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Painter>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public HttpStatusCode DeletePainter(long id)
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
