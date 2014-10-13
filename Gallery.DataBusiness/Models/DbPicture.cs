using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.DataBusiness.Models
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
        public long? PictureDescriptionId { get; set; }
        [ForeignKey("PictureDescriptionId")]
        public virtual DbDescription PictureDescription { get; set; }
        [ForeignKey("PictureDepartamentId")]
        public virtual DbDepartament DbDepartament { get; set; }
        [ForeignKey("PicturePainterId")]
        public virtual DbPainter Painter { get; set; }
        [ForeignKey("PictureGenreId")]
        public virtual DbGenre Genre { get; set; }
        public virtual ICollection<DbComment> Comments { get; set; }
        public virtual ICollection<DbImage> Images { get; set; }
    }
}
