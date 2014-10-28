using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.WebUI.Helpers;

namespace Gallery.WebUI.CustomAttribute
{
    public class PageAuthorizeAttribute: AuthorizeAttribute
    {
        public string UserRoles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCooke = httpContext.Request.Cookies["__AUTH"];
            if (authCooke == null) return false;
            var accountUtil=new AccountUtil(ConfigHeper.AccountApiUrl);
            var user = accountUtil.GetUserByEmail(authCooke.Value);
            return UserRoles.Split(',').Any(x => String.Equals(x.Trim(), user.Role.RoleName.Trim(), StringComparison.CurrentCultureIgnoreCase));
        }
    }
}