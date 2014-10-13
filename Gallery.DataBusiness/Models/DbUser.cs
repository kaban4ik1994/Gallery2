using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.DataBusiness.Models
{
    [Table("Users")]
    public class DbUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public long UserRoleId { get; set; }
        [ForeignKey("UserRoleId")]
        public virtual DbRole Role { get; set; }
        public virtual List<DbComment> DbComments { get; set; }
    }
}
