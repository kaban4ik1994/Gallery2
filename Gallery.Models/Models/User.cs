using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Models.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public long UserId { get; set; }
        [JsonProperty("Name")]
        public string UserName { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("PasswordHash")]
        public string PasswordHash { get; set; }
        [JsonProperty("RoleId")]
        public long? UserRoleId { get; set; }
        [JsonProperty("Role")]
        public Role Role { get; set; }
        [JsonProperty("Comments")]
        public ICollection<Comment> Comments { get; set; }
        [JsonProperty("Tokens")]
        public ICollection<Token> Tokens { get; set; }
    }
}
