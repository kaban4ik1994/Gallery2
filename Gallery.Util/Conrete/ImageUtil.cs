using System.Collections.Generic;
using System.Net.Http;
using Gallery.Models.Models;
using Gallery.Util.Helpers;
using Gallery.Util.Interfaces;
using Newtonsoft.Json;

namespace Gallery.Util.Conrete
{
    public class ImageUtil: IImageUtil
    {
        public string ApiUrl { get; private set; }

        public ImageUtil(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public Image GetPictureImageData(long id, int minHeight,
         int minWidth, int maxHeight, int maxWidth)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.GetAsync(RequestHelper.GenerateRequestUrl(ApiUrl,
                        new Dictionary<string, object>
                        {
                            { "command", "PictureImage" },
                            {"id", id},
                            {"minHeight", minHeight},
                            {"minWidth", minWidth},
                            {"maxHeight", maxHeight},
                            {"maxWidth", maxWidth},
                        })).Result;
                return result.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Image>(result.Content.ReadAsStringAsync().Result) : null;
            }
        }
    }
}
