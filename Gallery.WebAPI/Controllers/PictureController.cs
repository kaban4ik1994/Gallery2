using System.Linq;
using System.Web.Http;
using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
using Gallery.WebAPI.Helpers;
using Newtonsoft.Json;

namespace Gallery.WebAPI.Controllers
{
    public class PictureController : ApiController
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var dbPictures = _pictureService.GetPictures().ToList();
            var pictures = dbPictures.Select(Mapper.Map<Picture>).ToList();
            return Json(pictures, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var dbPicture = _pictureService.GetPictureById(id);
            if (dbPicture == null) return BadRequest("Genre not found!");
            var picture = Mapper.Map<Picture>(dbPicture);
            return Json(picture, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var dbPicture = _pictureService.GetPictureByName(name);
            if (dbPicture == null) return BadRequest("Genre not found!");
            var picture = Mapper.Map<Picture>(dbPicture);
            return Json(picture, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPut]
        public IHttpActionResult Put(Picture picture)
        {
            var origImage = picture.Images.First();
            if (origImage == null) return BadRequest("Error!");
            var imageExtension =
    ImageConverter.ImageConverter.GetImageFormat(
        ImageConverter.ImageConverter.ByteArrayToImage(origImage.ImageData)).ToString();
            origImage.ImageExtension = imageExtension;
            var newImage100X100 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "1",
                imageExtension, 100, 100);
            var newImage300X300 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "2",
               imageExtension, 300, 300);
            var newImage700X700 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "3",
               imageExtension, 700, 700);
            picture.Images.Add(newImage100X100);
            picture.Images.Add(newImage300X300);
            picture.Images.Add(newImage700X700);
            var dbPicture = Mapper.Map<DbPicture>(picture);
            _pictureService.CreatePicture(dbPicture);
            return Json(Mapper.Map<Picture>(dbPicture), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public IHttpActionResult Post(Picture picture)
        {
            var origImage = picture.Images.First();
            if (origImage == null) return BadRequest("Error!");
            var dbPicture = Mapper.Map<DbPicture>(picture);

            var imageExtension =
                 ImageConverter.ImageConverter.GetImageFormat(
                     ImageConverter.ImageConverter.ByteArrayToImage(origImage.ImageData)).ToString();
            origImage.ImageExtension = imageExtension;
            var newImage100X100 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "1",
                imageExtension, 100, 100);
            var newImage300X300 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "2",
                imageExtension, 300, 300);
            var newImage700X700 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "3",
                imageExtension, 700, 700);

            dbPicture.Images.ElementAt(0).ImageData = origImage.ImageData;
            dbPicture.Images.ElementAt(0).ImageExtension = imageExtension;
            dbPicture.Images.ElementAt(0).ImageHeight = origImage.ImageHeight;
            dbPicture.Images.ElementAt(0).ImageWidth = origImage.ImageWidth;
            dbPicture.Images.ElementAt(0).ImageName = origImage.ImageName;

            dbPicture.Images.ElementAt(1).ImageData = newImage100X100.ImageData;
            dbPicture.Images.ElementAt(1).ImageExtension = newImage100X100.ImageExtension;
            dbPicture.Images.ElementAt(1).ImageHeight = newImage100X100.ImageHeight;
            dbPicture.Images.ElementAt(1).ImageWidth = newImage100X100.ImageWidth;
            dbPicture.Images.ElementAt(1).ImageName = newImage100X100.ImageName;

            dbPicture.Images.ElementAt(2).ImageData = newImage300X300.ImageData;
            dbPicture.Images.ElementAt(2).ImageExtension = newImage300X300.ImageExtension;
            dbPicture.Images.ElementAt(2).ImageHeight = newImage300X300.ImageHeight;
            dbPicture.Images.ElementAt(2).ImageWidth = newImage300X300.ImageWidth;
            dbPicture.Images.ElementAt(2).ImageName = newImage300X300.ImageName;

            dbPicture.Images.ElementAt(3).ImageData = newImage700X700.ImageData;
            dbPicture.Images.ElementAt(3).ImageExtension = newImage700X700.ImageExtension;
            dbPicture.Images.ElementAt(3).ImageHeight = newImage700X700.ImageHeight;
            dbPicture.Images.ElementAt(3).ImageWidth = newImage700X700.ImageWidth;
            dbPicture.Images.ElementAt(3).ImageName = newImage700X700.ImageName;

            _pictureService.UpdatePicture(dbPicture);
            return Json(Mapper.Map<Picture>(dbPicture), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            _pictureService.DeletePicture(id);
            return Ok();
        }
    }
}
