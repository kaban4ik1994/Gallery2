using System.Web.Mvc;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.CustomAttribute;
using Gallery.WebUI.Helpers;
using System.Linq;
using AutoMapper;
using Gallery.WebUI.Models.Picture;

namespace Gallery.WebUI.Controllers
{
    using System.Globalization;

    [PageAuthorize(UserRoles = "admin")]
    public class PictureController : Controller
    {
        private readonly IPictureUtil _pictureUtil;

        private readonly IPainterUtil _painterUtil;

        private readonly IDepartamentUtil _departamentUtil;

        private readonly IGenreUtil _genreUtil;

        public PictureController()
        {
            _pictureUtil = new PictureUtil(ConfigHeper.PictureApiUrl);
            _painterUtil = new PainterUtil(ConfigHeper.PainterApiUrl);
            _departamentUtil = new DepartamentUtil(ConfigHeper.DepartamentApiUrl);
            _genreUtil = new GenreUtil(ConfigHeper.GenreApiUrl);
        }
        public ActionResult Index()
        {
            var pictures = _pictureUtil.GetPicturess();
            var model = pictures.Select(Mapper.Map<PictureViewModel>).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreatePicture()
        {
            ViewBag.PainterSelection =
                _painterUtil.GetPainters()
                    .Select(h => new SelectListItem { Value = h.PainterId.ToString(CultureInfo.InvariantCulture), Text = h.PainterFullName });
            ViewBag.DepartamentSelection =
                _departamentUtil.GetDepartaments()
                    .Select(h => new SelectListItem { Value = h.DepartamentId.ToString(CultureInfo.InvariantCulture), Text = h.DepartamentName });
            ViewBag.GenreSelection =
                _genreUtil.GetGenres()
                    .Select(h => new SelectListItem { Value = h.GenreId.ToString(CultureInfo.InvariantCulture), Text = h.GenreName });



            return View(new PictureViewModel());
        }
    }
}