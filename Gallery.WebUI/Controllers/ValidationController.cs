using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.WebUI.Helpers;

namespace Gallery.WebUI.Controllers
{
    public class ValidationController : Controller
    {
        private readonly AccountUtil _accountUtil;

        public ValidationController()
        {
            _accountUtil = new AccountUtil(ConfigHeper.AccountApiUrl);
        }

        public JsonResult EmailExists(string email)
        {
            var result = _accountUtil.GetUserByEmail(email) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}