using System.ComponentModel.DataAnnotations;

namespace Gallery.WebUI.Models.Departament
{
    public class AddDepartamentViewModel
    {
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Number")]
        public string Number { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}