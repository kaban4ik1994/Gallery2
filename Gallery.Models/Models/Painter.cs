using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Models.Models
{
    public class Painter
    {
        [JsonProperty("Id")]
        public long PainterId { get; set; }
        [JsonProperty("Name")]
        public string PainterFullName { get; set; }
        [JsonProperty("Pictures")]
        public ICollection<Picture> Pictures { get; set; }
    }
}
