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
            _accountUtil = new AccountUtil("http://localhost:19349/api/account");
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
                _accountUtil.GetUserByEmailAndPasswordHash(model.Email, SecurityHelper.Hash(model.Password));
            }
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _accountUtil.Registration(new User
                {
                    Email = model.Email,
                    PasswordHash = SecurityHelper.Hash(model.Password),
                    UserName = model.UserName
                });
            }
            return View();
        }
    }
}