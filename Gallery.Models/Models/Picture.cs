using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Models.Models
{
    public class Picture
    {
        [JsonProperty("Id")]
        public long PictureId { get; set; }
        [JsonProperty("Name")]
        public string PictureName { get; set; }
        [JsonProperty("DepartamentId")]
        public long PictureDepartamentId { get; set; }
        [JsonProperty("PainterId")]
        public long PicturePainterId { get; set; }
        [JsonProperty("GenreId")]
        public long PictureGenreId { get; set; }
        [JsonProperty("Departament")]
        public virtual Departament Departament { get; set; }
        [JsonProperty("Painter")]
        public virtual Painter Painter { get; set; }
        [JsonProperty("Genre")]
        public virtual Genre Genre { get; set; }
        [JsonProperty("Comments")]
        public virtual ICollection<Comment> Comments { get; set; }
        [JsonProperty("Images")]
        public virtual ICollection<Image> Images { get; set; }
    }
}
