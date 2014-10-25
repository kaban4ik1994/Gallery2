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
        [JsonProperty("Number")]
        public long DepartamentNumber { get; set; }
        [JsonProperty("DescriptionId")]
        public long DepartamentDescriptionId { get; set; }
        [JsonProperty("Pictures")]
        public virtual ICollection<Picture> Picture { get; set; }
    }
}
