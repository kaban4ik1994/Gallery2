using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Gallery.Models.Models;
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
            var model = departaments.Select(Mapper.Map<DepartamentViewModel>).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateDepartament()
        {
            return View(new DepartamentViewModel());
        }
        [HttpPost]
        public ActionResult CreateDepartament(DepartamentViewModel model)
        {
            var departament = Mapper.Map<Departament>(model);
            _departamentUtil.CreateDepartament(departament);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDepartament(long id)
        {
            var departament = _departamentUtil.GetDepartamentById(id);
            var model = Mapper.Map<DepartamentViewModel>(departament);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartament(DepartamentViewModel model)
        {
            var departament = Mapper.Map<Departament>(model);
            _departamentUtil.UpdateDepartament(departament);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteDepartament(long id)
        {
            _departamentUtil.DeleteDepartament(id);
            return RedirectToAction("Index");
        }

    }
}