using System.Linq;
using System.Web.Http;
using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
using Newtonsoft.Json;

namespace Gallery.WebAPI.Controllers
{
    public class GenreController : ApiController
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var dbGenres = _genreService.GetGenres().ToList();
            var genres = dbGenres.Select(Mapper.Map<Genre>).ToList();
            return Json(genres, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var dbGenre = _genreService.GetGenreById(id);
            if (dbGenre == null) return BadRequest("Genre not found!");
            var genre = Mapper.Map<Genre>(dbGenre);
            return Json(genre, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var dbGenre = _genreService.GetGenreByName(name);
            if (dbGenre == null) return BadRequest("Genre not found!");
            var genre = Mapper.Map<Genre>(dbGenre);
            return Json(genre, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPut]
        public IHttpActionResult Put(Genre genre)
        {
            var dbGenre = Mapper.Map<DbGenre>(genre);
            _genreService.CreateGenre(dbGenre);
            return Json(Mapper.Map<Genre>(dbGenre), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public IHttpActionResult Post(Genre genre)
        {
            var dbGenre = Mapper.Map<DbGenre>(genre);
            _genreService.UpdateGenre(dbGenre);
            return Json(Mapper.Map<Genre>(dbGenre), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            _genreService.DeleteGenre(id);
            return Ok();
        }
    }
}
