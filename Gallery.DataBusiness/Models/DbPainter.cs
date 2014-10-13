using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.DataBusiness.Models
{
    [Table("Painters")]
    public class DbPainter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PainterId { get; set; }
        public string PainterFullName { get; set; }
        public virtual ICollection<DbPicture> Pictures { get; set; }
        public virtual ICollection<DbImage> Images { get; set; }
    }
}
