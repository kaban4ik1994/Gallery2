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

        public JsonResult DepartamentExists(long id, string name)
        {
            var departament = _departamentUtil.GetDepartamentByName(name);
            var result = departament == null || departament.DepartamentId == id;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GenreExists(long id, string name)
        {
            var genre = _genreUtil.GetGenreByName(name);
            var result = genre == null || genre.GenreId == id;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PainterExists(long id, string name)
        {
            var painter = _painterUtil.GetPainterByName(name);
            var result = painter == null || painter.PainterId == id;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}