using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Models.Models
{
    public class Genre
    {
        [JsonProperty("Id")]
        public long GenreId { get; set; }
        [JsonProperty("Name")]
        public string GenreName { get; set; }
        [JsonProperty("Pictures")]
        public ICollection<Picture> Pictures { get; set; } 
    }
}
