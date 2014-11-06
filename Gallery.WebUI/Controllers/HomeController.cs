using System.Collections.Generic;
using System.Web.Mvc;
using Gallery.WebUI.Models.Home;

namespace Gallery.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private static List<HomeViewModel> _testData = new List<HomeViewModel> //нужно подумать насчет ссылок
        {
            new HomeViewModel{Name = "Picture1", ImageUrl = "/Images/Pictures/1.png"},
            new HomeViewModel{Name = "Picture2", ImageUrl = "/Images/Pictures/2.png"},
            new HomeViewModel{Name = "Picture3", ImageUrl = "/Images/Pictures/3.png"}
        };

        public ActionResult Index(string departament)
        {
            ViewBag.ActiveItem = departament;
            return View(_testData);
        }
    }
}