using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.CustomAttribute;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Departament;

namespace Gallery.WebUI.Controllers
{
    public class DepartamentController : Controller
    {
        private readonly IDepartamentUtil _departamentUtil;

        public DepartamentController()
        {
            _departamentUtil = new DepartamentUtil(ConfigHeper.DepartamentApiUrl);
        }

        [PageAuthorize(UserRoles = "admin")]
        public ActionResult Index()
        {
            var departaments = _departamentUtil.GetDepartaments();
            var model = departaments.Select(departament => new DepartamentViewModel
            {
                Id = departament.DepartamentId,
                Description = departament.DepartamentDescription,
                Name = departament.DepartamentName,
                Number = departament.DepartamentNumber,
            }).ToList();
            return View(model);
        }

    }
}