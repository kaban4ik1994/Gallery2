using System;
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
    public class PictureUtil : IPictureUtil
    {
        public string ApiUrl { get; private set; }

        public PictureUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }
        public IEnumerable<Picture> GetPicturess()
        {
            using (var client = new HttpClient())
            {
                client.CancelPendingRequests();
                var result =
                    client.GetAsync(ApiUrl).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<Picture>>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Picture GetPictureById(long id)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "id", id } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Picture>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Picture GetPictureByName(string name)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object> { { "name", name } })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Picture>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

       

        public Picture CreatePicture(Picture picture)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PutAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(picture), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Picture>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public Picture UpdatePicture(Picture picture)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(picture), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Picture>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }

        public HttpStatusCode DeletePicture(long id)
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
