using System.Web.Mvc;
using Gallery.Models.Models;
using Gallery.Util.Conrete;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Account;

namespace Gallery.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountUtil _accountUtil;
        public AccountController()
        {
            _accountUtil = new AccountUtil(ConfigHeper.AccountApiUrl);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _accountUtil.GetUserByEmailAndPasswordHash(model.Email, SecurityHelper.Hash(model.Password));
                if (user != null)
                {
                    AuthHelper.LogInUser(HttpContext, user.Email);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _accountUtil.Registration(new User
                  {
                      Email = model.Email,
                      PasswordHash = SecurityHelper.Hash(model.Password),
                      UserName = model.UserName
                  });
                AuthHelper.LogInUser(HttpContext, user.Email);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            AuthHelper.LogOffUser(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}