using System.ComponentModel.DataAnnotations;

namespace Gallery.WebUI.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fill in the field.")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}