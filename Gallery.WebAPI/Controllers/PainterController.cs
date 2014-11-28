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
        private readonly IImageService _imageService;

        public PainterController(IPainterService painterService, IImageService imageService)
        {
            _painterService = painterService;
            _imageService = imageService;

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var dbPainters = _painterService.GetPainters().ToList();
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
            var dbPainter = Mapper.Map<DbPainter>(painter);
            _painterService.CreatePainter(dbPainter);
            return Json(Mapper.Map<Painter>(dbPainter), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public IHttpActionResult Post(Painter painter)
        {
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