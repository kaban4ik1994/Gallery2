using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.Helpers;

namespace Gallery.WebUI.Controllers
{
    public class ValidationController : Controller
    {
        private readonly IAccountUtil _accountUtil;
        private readonly IDepartamentUtil _departamentUtil;
        private readonly IGenreUtil _genreUtil;
        private readonly IPainterUtil _painterUtil;

        public ValidationController()
        {
            _accountUtil = new AccountUtil(ConfigHeper.AccountApiUrl);
            _departamentUtil = new DepartamentUtil(ConfigHeper.DepartamentApiUrl);
            _genreUtil = new GenreUtil(ConfigHeper.GenreApiUrl);
            _painterUtil = new PainterUtil(ConfigHeper.PainterApiUrl);
        }

        public JsonResult EmailExists(string email)
        {
            var result = _accountUtil.GetUserByEmail(email) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DepartamentExists(string name)
        {
            var result = _departamentUtil.GetDepartamentByName(name) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GenreExists(string name)
        {
            var result = _genreUtil.GetGenreByName(name) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PainterExists(string name)
        {
            var result = _painterUtil.GetPainterByName(name) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}