using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.CustomAttribute;
using Gallery.WebUI.Helpers;

namespace Gallery.WebUI.Controllers
{
    [PageAuthorize(UserRoles = "admin")]
    public class PictureController : Controller
    {
        private readonly IPictureUtil _pictureUtil;

        public PictureController()
        {
            _pictureUtil = new PictureUtil(ConfigHeper.PictureApiUrl);
        }
        // GET: Picture
        public ActionResult Index()
        {
            return View();
        }
    }
}