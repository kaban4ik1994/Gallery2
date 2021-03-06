﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Entities
{
    [Table("Comments")]
    public class DbComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CommentId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
        public string Content { get; set; }
        public long CommentPictureId { get; set; }
        public long CommentUserId { get; set; }
        [ForeignKey("CommentPictureId")]
        public DbPicture Picture { get; set; }
        [ForeignKey("CommentUserId")]
        public DbUser User { get; set; }
    }
}
