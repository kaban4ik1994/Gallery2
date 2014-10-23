using System.Web.Mvc;

namespace Gallery.WebUI.Controllers
{
    public class ValidationController : Controller
    {

        public JsonResult UserNameExists(string userName)
        {
            var result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmailExists(string email)
        {
            var result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}