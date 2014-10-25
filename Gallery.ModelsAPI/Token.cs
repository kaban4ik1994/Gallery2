using Newtonsoft.Json;

namespace Gallery.ModelsAPI
{
    public class Token
    {
        [JsonProperty("Id")]
        public long TokenId { get; set; }
        [JsonProperty("Content")]
        public string TokenContent { get; set; }
        [JsonProperty("UserId")]
        public long UserId { get; set; }
        [JsonProperty("User")]
        public virtual User User { get; set; }
    }
}
