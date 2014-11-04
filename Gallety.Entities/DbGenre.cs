using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Genres")]
    public class DbGenre
    {
        public DbGenre()
        {
            Pictures=new List<DbPicture>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<DbPicture> Pictures { get; set; }
    }
}
