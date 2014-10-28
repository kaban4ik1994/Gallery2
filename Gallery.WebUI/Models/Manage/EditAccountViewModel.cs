using System.ComponentModel.DataAnnotations;

namespace Gallery.WebUI.Models.Manage
{
    public class EditAccountViewModel
    {
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Name")]
        public string UserName { get; set; }
    }
}