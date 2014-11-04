using System.Linq;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Internal;
using Gallery.Entities;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
using Gallery.WebAPI.Helpers;
using Newtonsoft.Json;

namespace Gallery.WebAPI.Controllers
{
    public class PainterController : ApiController
    {
        private readonly IPainterService _painterService;
        private readonly IImageService _imageService;

        public PainterController(IPainterService painterService, IImageService imageService)
        {
            _painterService = painterService;
            _imageService = imageService;

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var dbPainters = _painterService.GetPainters();
            var painters = dbPainters.Select(Mapper.Map<Painter>).ToList();
            return Json(painters, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var dbPainter = _painterService.GetPainterById(id);
            if (dbPainter == null) return BadRequest("Painter not found!");
            var painter = Mapper.Map<Painter>(dbPainter);
            return Json(painter, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var dbPainter = _painterService.GetPainterByName(name);
            if (dbPainter == null) return BadRequest("Painter not found!");
            var painter = Mapper.Map<Painter>(dbPainter);
            return Json(painter, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPut]
        public IHttpActionResult Put(Painter painter)
        {
            var origImage = painter.Images.First();
            if (origImage == null) return BadRequest("Error!");
            var imageExtension =
    ImageConverter.ImageConverter.GetImageFormat(
        ImageConverter.ImageConverter.ByteArrayToImage(origImage.ImageData)).ToString();
            origImage.ImageExtension = imageExtension;
            var newImage100X100 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "100X100",
                imageExtension, 100, 100);
            var newImage300X300 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "300X300",
               imageExtension, 300, 300);
            var newImage700X700 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "700X700",
               imageExtension, 700, 700);
            painter.Images.Add(newImage100X100);
            painter.Images.Add(newImage300X300);
            painter.Images.Add(newImage700X700);
            var dbPainter = Mapper.Map<DbPainter>(painter);
            _painterService.CreatePainter(dbPainter);
            return Json(Mapper.Map<Painter>(dbPainter), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public IHttpActionResult Post(Painter painter)
        {
            var origImage = painter.Images.First();
            if (origImage == null) return BadRequest("Error!");
            var dbPainter = Mapper.Map<DbPainter>(painter);

            var imageExtension =
                 ImageConverter.ImageConverter.GetImageFormat(
                     ImageConverter.ImageConverter.ByteArrayToImage(origImage.ImageData)).ToString();
            origImage.ImageExtension = imageExtension;
            var newImage100X100 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "100X100",
                imageExtension, 100, 100);
            var newImage300X300 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "300X300",
                imageExtension, 300, 300);
            var newImage700X700 = ImageConverterHelper.ResizeImage(origImage, origImage.ImageName + "700X700",
                imageExtension, 700, 700);

            dbPainter.Images.ElementAt(0).ImageData = origImage.ImageData;
            dbPainter.Images.ElementAt(0).ImageExtension = imageExtension;
            dbPainter.Images.ElementAt(0).ImageHeight = origImage.ImageHeight;
            dbPainter.Images.ElementAt(0).ImageWidth = origImage.ImageWidth;
            dbPainter.Images.ElementAt(0).ImageName = origImage.ImageName;

            dbPainter.Images.ElementAt(1).ImageData = newImage100X100.ImageData;
            dbPainter.Images.ElementAt(1).ImageExtension = newImage100X100.ImageExtension;
            dbPainter.Images.ElementAt(1).ImageHeight = newImage100X100.ImageHeight;
            dbPainter.Images.ElementAt(1).ImageWidth = newImage100X100.ImageWidth;
            dbPainter.Images.ElementAt(1).ImageName = newImage100X100.ImageName;

            dbPainter.Images.ElementAt(2).ImageData = newImage300X300.ImageData;
            dbPainter.Images.ElementAt(2).ImageExtension = newImage300X300.ImageExtension;
            dbPainter.Images.ElementAt(2).ImageHeight = newImage300X300.ImageHeight;
            dbPainter.Images.ElementAt(2).ImageWidth = newImage300X300.ImageWidth;
            dbPainter.Images.ElementAt(2).ImageName = newImage300X300.ImageName;

            dbPainter.Images.ElementAt(3).ImageData = newImage700X700.ImageData;
            dbPainter.Images.ElementAt(3).ImageExtension = newImage700X700.ImageExtension;
            dbPainter.Images.ElementAt(3).ImageHeight = newImage700X700.ImageHeight;
            dbPainter.Images.ElementAt(3).ImageWidth = newImage700X700.ImageWidth;
            dbPainter.Images.ElementAt(3).ImageName = newImage700X700.ImageName;

            _imageService.UpdateImage(dbPainter.Images.ElementAt(0));
            _imageService.UpdateImage(dbPainter.Images.ElementAt(1));
            _imageService.UpdateImage(dbPainter.Images.ElementAt(2));
            _imageService.UpdateImage(dbPainter.Images.ElementAt(3));

            _painterService.UpdatePainter(dbPainter);
            return Json(Mapper.Map<Painter>(dbPainter), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        }

        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            _painterService.DeletePainter(id);
            return Ok();
        }
    }
}