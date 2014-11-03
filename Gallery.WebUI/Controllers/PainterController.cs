using System.Collections.Generic;
using System.IO;
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
            var genres = _painterUtil.GetPainters();
            var model = genres.Select(Mapper.Map<PainterViewModel>).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult CreatePainter()
        {
            return View(new PainterViewModel());
        }

        [HttpPost]
        public ActionResult CreatePainter(PainterViewModel model, HttpPostedFileBase imageData)
        {

            if (!ModelState.IsValid || imageData == null) return RedirectToAction("Index", "Error");
            var genre = Mapper.Map<Painter>(model);
            var tempImage = new Image { ImageData = new byte[imageData.ContentLength] };
            imageData.InputStream.Read(tempImage.ImageData, 0, imageData.ContentLength);
            tempImage.ImageName = imageData.FileName;
            tempImage.ImageExtension = imageData.ContentType.Split('/').Last();
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(imageData.InputStream, true, true))
            {
                tempImage.ImageHeight = image.Height;
                tempImage.ImageWidth = image.Width;
            }
            genre.Images = new List<Image> { tempImage };
            _painterUtil.CreatePainter(genre);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult EditGenre(long id)
        //{
        //    var genre = _genreUtil.GetGenreById(id);
        //    var model = Mapper.Map<GenreViewModel>(genre);
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditGenre(GenreViewModel model)
        //{
        //    var genre = Mapper.Map<Genre>(model);
        //    _genreUtil.UpdateGenre(genre);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult DeleteGenre(long id)
        //{
        //    _genreUtil.DeleteGenre(id);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public FileContentResult ConvertImageToFileContent(long imageId)
        //{

        //    return File(System.Text.Encoding.UTF8.GetBytes(imageData), imageName);
        //}
    }
}