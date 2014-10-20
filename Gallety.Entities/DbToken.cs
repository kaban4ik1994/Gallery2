using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallety.Entities
{
    [Table("Tokens")]
    public class DbToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TokenId { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual DbUser User { get; set; }
    }
}
