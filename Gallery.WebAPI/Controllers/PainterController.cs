using System.Web.Http;
using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
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
        public IHttpActionResult Get(long id)
        {
            var dbPainter = _painterService.GetPainterById(id);
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