using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Models.Models
{
    public class Role
    {
        [JsonProperty("Id")]
        public long RoleId { get; set; }
        [JsonProperty("Name")]
        public string RoleName { get; set; }
        [JsonProperty("Users")]
        public virtual ICollection<User> Users { get; set; }
    }
}
