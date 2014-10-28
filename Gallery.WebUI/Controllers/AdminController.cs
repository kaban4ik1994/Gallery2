using System.Web.Mvc;
using Gallery.WebUI.CustomAttribute;

namespace Gallery.WebUI.Controllers
{
    [PageAuthorize(UserRoles = "admin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}