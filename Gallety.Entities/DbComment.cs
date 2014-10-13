using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallety.Entities
{
    [Table("Comments")]
    public class DbComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CommentId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public long CommentPictureId { get; set; }
        [ForeignKey("CommentPictureId")]
        public virtual DbPicture Picture { get; set; }
    }
}
