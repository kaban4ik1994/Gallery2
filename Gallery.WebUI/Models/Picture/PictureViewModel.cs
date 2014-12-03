using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using Gallery.Models.Models;

namespace Gallery.WebUI.Models.Picture
{

    public class PictureViewModel
    {
        [HiddenInput]
        public long Id { get; set; }
        [Remote("PictureExist", "Validation", ErrorMessage = "Painter already exists.", AdditionalFields = "Id")]
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        public long DepartamentId { get; set; }
        public long PainterId { get; set; }
        public long GenreId { get; set; }
        [Display(Name = "Painter:")]
        public string PainterName { get; set; }
        [Display(Name = "Genre:")]
        public string GenreName { get; set; }
        [Display(Name = "Departament:")]
        public string DepartamentName { get; set; }
        public List<Comment> Comments { get; set; } 
        public List<Gallery.Models.Models.Image> Images { get; set; }
        public List<SelectListItem> PainterSelectionList { get; set; }
        public List<SelectListItem> DepartamentSelectionList { get; set; }
        public List<SelectListItem> GenreSelectionList { get; set; }
    }
}