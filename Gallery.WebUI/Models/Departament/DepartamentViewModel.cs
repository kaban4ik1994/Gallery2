using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace Gallery.WebUI.Models.Departament
{
    public class DepartamentViewModel
    {
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill in the field.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
       
    }
}