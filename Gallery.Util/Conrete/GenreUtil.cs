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
    public class GenreUtil : IGenreUtil
    {
        public string ApiUrl { get; private set; }

        public GenreUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public IEnumerable<Genre> GetGenres()
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(ApiUrl).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<Genre>>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Genre GetGenreById(long id)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "id", id } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Genre>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Genre GetGenreByName(string name)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "name", name } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Genre>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Genre CreateGenre(Genre genre)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PutAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(genre), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Genre>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Genre UpdateGenre(Genre genre)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(genre), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Genre>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public HttpStatusCode DeleteGenre(long id)
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
