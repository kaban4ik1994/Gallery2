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
    public class PainterController : ApiController
    {
        private readonly IPainterService _painterService;

        public PainterController(IPainterService painterService)
        {
            _painterService = painterService;
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