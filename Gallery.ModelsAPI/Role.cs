using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.ModelsAPI
{
    public class Role
    {
        [JsonProperty("Id")]
        public long RoleId { get; set; }
        [JsonProperty("Name")]
        public string RoleName { get; set; }
        [JsonProperty("Users")]
        public ICollection<User> Users { get; set; }
    }
}
