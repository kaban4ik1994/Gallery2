using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Painters")]
    public class DbPainter
    {
        public DbPainter()
        {
            Pictures=new List<DbPicture>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PainterId { get; set; }
        public string PainterFullName { get; set; }
        public ICollection<DbPicture> Pictures { get; set; }
    }
}
