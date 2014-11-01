﻿using System;
using Newtonsoft.Json;

namespace Gallery.Models.Models
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
        public Picture Picture { get; set; }
    }
}
