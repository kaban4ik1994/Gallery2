using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("PainterImage")]
    public class DbPainterImage
    {
        public long PainterId { get; set; }
        public long Imageid { get; set; }

        [ForeignKey("PainterId")]
        public virtual DbPainter Painter { get; set; }
        [ForeignKey("Imageid")]
        public virtual DbImage Image { get; set; }
    }
}
