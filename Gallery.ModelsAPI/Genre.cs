using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.ModelsAPI
{
    public class Genre
    {
        [JsonProperty("Id")]
        public long GenreId { get; set; }
        [JsonProperty("Name")]
        public long GenreName { get; set; }
        [JsonProperty("Pictures")]
        public virtual ICollection<Picture> Pictures { get; set; } 
    }
}
