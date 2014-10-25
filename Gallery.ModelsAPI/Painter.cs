using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.ModelsAPI
{
    public class Painter
    {
        [JsonProperty("Id")]
        public long PainterId { get; set; }
        [JsonProperty("Name")]
        public string PainterFullName { get; set; }
        [JsonProperty("Pictures")]
        public virtual ICollection<Picture> Pictures { get; set; }
        [JsonProperty("Images")]
        public virtual ICollection<Image> Images { get; set; }
    }
}
