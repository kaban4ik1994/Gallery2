using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Departaments")]
    public class DbDepartament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DepartamentId { get; set; }
        public string DepartamentName { get; set; }
        public long DepartamentNumber { get; set; }
        public long DepartamentDescriptionId { get; set; }
        [ForeignKey("DepartamentDescriptionId")]
        public ICollection<DbPicture> Picture { get; set; }
    }
}
