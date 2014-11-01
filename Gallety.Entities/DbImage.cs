using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Images")]
    public class DbImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public long? ImagePainterId { get; set; }
        public long? ImagePictureId { get; set; }
        public long? ImageUserId { get; set; }
        [ForeignKey("ImagePainterId")]
        public DbPainter Painter { get; set; }
        [ForeignKey("ImagePictureId")]
        public DbPicture Picture { get; set; }
        [ForeignKey("ImageUserId")]
        public DbUser DbUser { get; set; }
    }
}
