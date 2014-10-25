using System;
using Newtonsoft.Json;

namespace Gallery.ModelsAPI
{
    public class Comment
    {
        [JsonProperty("Id")]
        public long CommentId { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("Content")]
        public string Content { get; set; }
        [JsonProperty("PictureId")]
        public long CommentPictureId { get; set; }
        [JsonProperty("Picture")]
        public virtual Picture Picture { get; set; }
    }
}
