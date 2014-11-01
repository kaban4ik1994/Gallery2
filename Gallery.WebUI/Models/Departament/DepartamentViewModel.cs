using System.Web.Mvc;

namespace Gallery.WebUI.Models.Departament
{
    public class DepartamentViewModel
    {
        [HiddenInput]
        public long Id { get; set; }
        public string Name { get; set; }
        public long Number { get; set; }
        public string Description { get; set; }
    }
}