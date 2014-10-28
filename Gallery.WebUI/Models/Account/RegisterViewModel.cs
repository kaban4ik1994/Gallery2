using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gallery.WebUI.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Fill in the field.")]
        [Remote("EmailExists", "Validation", ErrorMessage = "System doesn't have such E-mail.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fill in the field.")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}