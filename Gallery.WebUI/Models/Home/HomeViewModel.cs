using System.Collections.Generic;

namespace Gallery.WebUI.Models.Home
{
    public class HomeViewModel
    {
        public List<Gallery.Models.Models.Picture> Pictures { get; set; }
        public string SelectedDepartament { get; set; }
    }
}