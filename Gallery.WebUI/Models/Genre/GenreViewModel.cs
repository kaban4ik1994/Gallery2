using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gallery.WebUI.Models.Genre
{
    public class GenreViewModel
    {
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}