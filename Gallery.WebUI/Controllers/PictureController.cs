using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using Gallery.Models.Models;
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
            var model = new PictureViewModel
                            {
                                PainterSelectionList = _painterUtil.GetPainters().Select(x => new SelectListItem { Value = x.PainterId.ToString(CultureInfo.InvariantCulture), Text = x.PainterFullName }).ToList(),
                                DepartamentSelectionList = _departamentUtil.GetDepartaments().Select(x => new SelectListItem { Value = x.DepartamentId.ToString(CultureInfo.InvariantCulture), Text = x.DepartamentName }).ToList(),
                                GenreSelectionList = _genreUtil.GetGenres().Select(x => new SelectListItem { Value = x.GenreId.ToString(CultureInfo.InvariantCulture), Text = x.GenreName }).ToList(),
                            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePicture(PictureViewModel model, HttpPostedFileBase imageData)
        {
            if (!ModelState.IsValid || imageData == null) return RedirectToAction("Index", "Error");
            var painter = Mapper.Map<Picture>(model);
            var tempImage = new Image { ImageData = new byte[imageData.ContentLength] };
            imageData.InputStream.Read(tempImage.ImageData, 0, imageData.ContentLength);
            tempImage.ImageName = imageData.FileName;
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(imageData.InputStream, true, true))
            {
                tempImage.ImageHeight = image.Height;
                tempImage.ImageWidth = image.Width;
            }
            painter.Images = new List<Image> { tempImage };
            _pictureUtil.CreatePicture(painter);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPicture(long id)
        {
            var picture = _pictureUtil.GetPictureById(id);

            if (picture == null) return RedirectToAction("Index", "Error");
            var model = Mapper.Map<PictureViewModel>(picture);
            model.PainterSelectionList = _painterUtil.GetPainters().Select(x => new SelectListItem { Value = x.PainterId.ToString(CultureInfo.InvariantCulture), Text = x.PainterFullName }).ToList();
            model.DepartamentSelectionList = _departamentUtil.GetDepartaments().Select(x => new SelectListItem { Value = x.DepartamentId.ToString(CultureInfo.InvariantCulture), Text = x.DepartamentName }).ToList();
            model.GenreSelectionList = _genreUtil.GetGenres().Select(x => new SelectListItem { Value = x.GenreId.ToString(CultureInfo.InvariantCulture), Text = x.GenreName }).ToList();
            TempData["Images"] = model.Images;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPicture(PictureViewModel model, HttpPostedFileBase imageData)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Error");
            var picture = Mapper.Map<Picture>(model);
            picture.Images = (List<Image>)TempData["Images"];
            if (imageData != null)
            {
                var tempImage = new Image { ImageData = new byte[imageData.ContentLength] };
                imageData.InputStream.Read(tempImage.ImageData, 0, imageData.ContentLength);
                tempImage.ImageName = imageData.FileName;
                using (var image = System.Drawing.Image.FromStream(imageData.InputStream, true, true))
                {
                    tempImage.ImageHeight = image.Height;
                    tempImage.ImageWidth = image.Width;
                }

                picture.Images.First().ImageData = tempImage.ImageData;
                picture.Images.First().ImageName = tempImage.ImageName;
                picture.Images.First().ImageWidth = tempImage.ImageWidth;
                picture.Images.First().ImageHeight = tempImage.ImageHeight;
            }
            _pictureUtil.UpdatePicture(picture);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeletePicture(long id)
        {
            _pictureUtil.DeletePicture(id);
            return RedirectToAction("Index");
        }
    }
}