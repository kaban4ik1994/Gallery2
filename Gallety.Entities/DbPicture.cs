using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Pictures")]
    public class DbPicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PictureId { get; set; }
        public string PictureName { get; set; }
        public long PictureDepartamentId { get; set; }
        public long PicturePainterId { get; set; }
        public long PictureGenreId { get; set; }
        [ForeignKey("PictureDepartamentId")]
        public DbDepartament DbDepartament { get; set; }
        [ForeignKey("PicturePainterId")]
        public DbPainter Painter { get; set; }
        [ForeignKey("PictureGenreId")]
        public DbGenre Genre { get; set; }
        public  ICollection<DbComment> Comments { get; set; }
        public  ICollection<DbImage> Images { get; set; }
    }
}
