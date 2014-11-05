using System.Collections.Generic;
using System.Web.Mvc;
using Gallery.WebUI.Models.Home;

namespace Gallery.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private static List<PictureViewModel> _testData = new List<PictureViewModel> //нужно подумать насчет ссылок
        {
            new PictureViewModel{Name = "Picture1", ImageUrl = "/Images/Pictures/1.png"},
            new PictureViewModel{Name = "Picture2", ImageUrl = "/Images/Pictures/2.png"},
            new PictureViewModel{Name = "Picture3", ImageUrl = "/Images/Pictures/3.png"}
        };

        public ActionResult Index(string departament)
        {
            ViewBag.ActiveItem = departament;
            return View(_testData);
        }
    }
}