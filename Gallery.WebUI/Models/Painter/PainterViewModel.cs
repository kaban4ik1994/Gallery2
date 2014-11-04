﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using Gallery.Models.Models;

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
        public List<Gallery.Models.Models.Image> Images { get; set; }
    }
}