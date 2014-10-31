using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Genres")]
    public class DbGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GenreId { get; set; }
        public long GenreName { get; set; }
        public ICollection<DbPicture> Pictures { get; set; }
    }
}
