using System.Net.Http;
using System.Text;
using Gallery.Models.Models;
using Gallery.Util.Interfaces;
using Newtonsoft.Json;

namespace Gallery.Util.Conrete
{
    public class CommentUtil : ICommentUtil
    {
        public string ApiUrl { get; private set; }

        public CommentUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public Comment CreateComment(Comment comment)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PutAsync(ApiUrl, new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Comment>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }
    }
}
