using Newtonsoft.Json;

namespace Gallery.ModelsAPI
{
    public class Image
    {
        [JsonProperty("Id")]
        public long ImageId { get; set; }
        [JsonProperty("Name")]
        public string ImageName { get; set; }
        [JsonProperty("Url")]
        public string ImageUrl { get; set; }
        [JsonProperty("Height")]
        public int ImageHeight { get; set; }
        [JsonProperty("Width")]
        public int ImageWidth { get; set; }
        [JsonProperty("PainterId")]
        public long? ImagePainterId { get; set; }
        [JsonProperty("PictureId")]
        public long? ImagePictureId { get; set; }
        [JsonProperty("UserId")]
        public long? ImageUserId { get; set; }
        [JsonProperty("Painter")]
        public virtual Painter Painter { get; set; }
        [JsonProperty("Picture")]
        public virtual Picture Picture { get; set; }
        [JsonProperty("User")]
        public virtual User User { get; set; }
    }
}
