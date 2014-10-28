using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Descriptions")]
    public class DbDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DescriptionId { get; set; }
        public string Description { get; set; }
        public long DescriptionDepartamentId { get; set; }
        [ForeignKey("DescriptionDepartamentId")]
        public virtual DbDepartament Departament { get; set; }
    }
}
