
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.DataBusiness.Models
{
    [Table("Descriptions")]
    public class DbDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DescriptionId { get; set; }
        public string Description { get; set; }
        public long? DescriptionPictureId { get; set; }
        public long? DescriptionGenreId { get; set; }
        public long? DescriptionDepartamentId { get; set; }
        [ForeignKey("DescriptionPictureId")]
        public virtual DbPicture Picture { get; set; }
        [ForeignKey("DescriptionGenreId")]
        public virtual DbGenre Genre { get; set; }
        [ForeignKey("DescriptionDepartamentId")]
        public virtual DbDepartament Departament { get; set; }
    }
}
