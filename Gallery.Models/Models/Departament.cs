using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Models.Models
{
    public class Departament
    {
        [JsonProperty("Id")]
        public long DepartamentId { get; set; }
        [JsonProperty("Name")]
        public string DepartamentName { get; set; }
        [JsonProperty("Description")]
        public string DepartamentDescription { get; set; } 
        [JsonProperty("Pictures")]
        public ICollection<Picture> Picture { get; set; }
    }
}
