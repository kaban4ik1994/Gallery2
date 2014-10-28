using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Manage;

namespace Gallery.WebUI.Controllers
{
    public class ManageController : Controller
    {
        private readonly AccountUtil _accountUtil;

        public ManageController()
        {
            _accountUtil = new AccountUtil(ConfigHeper.AccountApiUrl);
        }

        public ActionResult EditAccount()
        {
            var user = AuthHelper.GetUser(HttpContext, _accountUtil);

            return View(new EditAccountViewModel { UserName = user.UserName });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount(EditAccountViewModel editAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = AuthHelper.GetUser(HttpContext, _accountUtil);
                user.UserName = editAccountViewModel.UserName;
                _accountUtil.UpdateUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View(editAccountViewModel);
        }
    }
}