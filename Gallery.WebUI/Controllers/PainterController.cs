using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Gallery.Models.Models;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.CustomAttribute;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Painter;

namespace Gallery.WebUI.Controllers
{
    [PageAuthorize(UserRoles = "admin")]
    public class PainterController : Controller
    {
        private readonly IPainterUtil _painterUtil;

        public PainterController()
        {
            _painterUtil = new PainterUtil(ConfigHeper.PainterApiUrl);
        }
        // GET: Genre
        public ActionResult Index()
        {
            var painters = _painterUtil.GetPainters();
            var model = painters.Select(Mapper.Map<PainterViewModel>).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult CreatePainter()
        {
            return View(new PainterViewModel());
        }

        [HttpPost]
        public ActionResult CreatePainter(PainterViewModel model)
        {

            if (!ModelState.IsValid) return RedirectToAction("Index", "Error");
            var painter = Mapper.Map<Painter>(model);
            _painterUtil.CreatePainter(painter);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPainter(long id)
        {
            var painter = _painterUtil.GetPainterById(id);
            if (painter == null) return RedirectToAction("Index", "Error");
            var model = Mapper.Map<PainterViewModel>(painter);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPainter(PainterViewModel model, HttpPostedFileBase imageData)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Error");
            var painter = Mapper.Map<Painter>(model);
            _painterUtil.UpdatePainter(painter);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeletePainter(long id)
        {
            _painterUtil.DeletePainter(id);
            return RedirectToAction("Index");
        }
    }
}