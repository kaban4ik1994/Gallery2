﻿using System.ComponentModel.DataAnnotations;
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
        public byte[] ImageData { get; set; }
        public string ImageExtension { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public long ImagePictureId { get; set; }
        [ForeignKey("ImagePictureId")]
        public DbPicture Picture { get; set; }
    }
}
