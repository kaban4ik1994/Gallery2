using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.CustomAttribute;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Manage;

namespace Gallery.WebUI.Controllers
{
    public class ManageController : Controller
    {
        private readonly IAccountUtil _accountUtil;

        public ManageController()
        {
            _accountUtil = new AccountUtil(ConfigHeper.AccountApiUrl);
        }

        [PageAuthorize(UserRoles = "user,admin")]
        public ActionResult EditAccount()
        {
            var user = AuthHelper.GetUser(HttpContext, _accountUtil);

            return View(new EditAccountViewModel { UserName = user.UserName });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PageAuthorize(UserRoles = "user,admin")]
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