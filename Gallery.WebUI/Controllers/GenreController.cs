using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Gallery.Models.Models;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.CustomAttribute;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Genre;

namespace Gallery.WebUI.Controllers
{
    [PageAuthorize(UserRoles = "admin")]
    public class GenreController : Controller
    {
        private readonly IGenreUtil _genreUtil;

        public GenreController()
        {
            _genreUtil = new GenreUtil(ConfigHeper.GenreApiUrl);
        }
        // GET: Genre
        public ActionResult Index()
        {
            var genres = _genreUtil.GetGenres();
            var model = genres.Select(Mapper.Map<GenreViewModel>).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateGenre()
        {
            return View(new GenreViewModel());
        }
        [HttpPost]
        public ActionResult CreateGenre(GenreViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Error");
            var genre = Mapper.Map<Genre>(model);
            _genreUtil.CreateGenre(genre);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditGenre(long id)
        {
            var genre = _genreUtil.GetGenreById(id);
            var model = Mapper.Map<GenreViewModel>(genre);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGenre(GenreViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Error");
            var genre = Mapper.Map<Genre>(model);
            _genreUtil.UpdateGenre(genre);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteGenre(long id)
        {
            _genreUtil.DeleteGenre(id);
            return RedirectToAction("Index");
        }
    }
}