using Newtonsoft.Json;

namespace Gallery.ModelsAPI
{
    public class Description
    {
        [JsonProperty("Id")]
        public long DescriptionId { get; set; }
        [JsonProperty("Content")]
        public string DescriptionContent { get; set; }
        [JsonProperty("DepartamentId")]
        public long DescriptionDepartamentId { get; set; }
        [JsonProperty("Departament")]
        public virtual Departament Departament { get; set; }
    }
}
