using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallety.Entities
{
    [Table("Images")]
    public class DbImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageContent { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public long? ImagePainterId { get; set; }
        public long? ImagePictureId { get; set; }
        public long? ImageUserId { get; set; }
        [ForeignKey("ImagePainterId")]
        public virtual DbPainter Painter { get; set; }
        [ForeignKey("ImagePictureId")]
        public virtual DbPicture Picture { get; set; }
        [ForeignKey("ImageUserId")]
        public virtual DbUser DbUser { get; set; }
    }
}
