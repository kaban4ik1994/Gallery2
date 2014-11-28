using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gallery.WebUI.Models.Painter
{
    public class PainterViewModel
    {
        [HiddenInput]
        public long Id { get; set; }
        [Remote("PainterExists", "Validation", ErrorMessage = "Painter already exists.", AdditionalFields = "Id")]
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}