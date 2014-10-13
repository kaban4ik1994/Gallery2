using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallety.Entities
{
    [Table("Genres")]
    public class DbGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GenreId { get; set; }
        public long GenreName { get; set; }
        public long GenreDescriptionId { get; set; }
        [ForeignKey("GenreDescriptionId")]
        public DbDescription GenreDescription { get; set; }
        public virtual ICollection<DbPicture> Pictures { get; set; } 
    }
}
