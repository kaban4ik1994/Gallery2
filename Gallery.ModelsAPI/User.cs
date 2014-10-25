using System.Collections.Generic;

namespace Gallery.ModelsAPI
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public long UserRoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Token> Tokens { get; set; }
    }
}
