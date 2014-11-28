using Newtonsoft.Json;

namespace Gallery.Models.Models
{
    public class Image
    {
        [JsonProperty("Id")]
        public long ImageId { get; set; }
        [JsonProperty("Name")]
        public string ImageName { get; set; }
        [JsonProperty("Extension")]
        public string ImageExtension { get; set; }
        [JsonProperty("Url")]
        public byte[] ImageData { get; set; }
        [JsonProperty("Height")]
        public int ImageHeight { get; set; }
        [JsonProperty("Width")]
        public int ImageWidth { get; set; }
        [JsonProperty("PainterId")]
        public long ImagePictureId { get; set; }
        [JsonProperty("Picture")]
        public Picture Picture { get; set; }

    }
}
