using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
using Newtonsoft.Json;

namespace Gallery.WebAPI.Controllers
{
    public class DepartamentController : ApiController
    {
        private readonly IDepartamentService _departamentService;

        public DepartamentController(IDepartamentService departamentService)
        {
            _departamentService = departamentService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var dbDepartaments = _departamentService.GetDepartaments();
            var departaments = dbDepartaments.Select(Mapper.Map<Departament>).ToList();
            return Json(departaments, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var dbDepartament = _departamentService.GetDepartamentById(id);
            if (dbDepartament == null) return BadRequest("Departament not found!");
            var departament = Mapper.Map<Departament>(dbDepartament);
            return Json(departament, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPut]
        public IHttpActionResult Put(Departament departament)
        {
            var dbDepartament = Mapper.Map<DbDepartament>(departament);
            _departamentService.CreateDepartament(dbDepartament);
            return Json(Mapper.Map<Departament>(dbDepartament), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public IHttpActionResult Post(Departament departament)
        {
            var dbDepartament = Mapper.Map<DbDepartament>(departament);
            _departamentService.UpdateDepartament(dbDepartament);
            return Json(Mapper.Map<Departament>(dbDepartament), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            _departamentService.DeleteDepartament(id);
            return Ok();
        }
    }
}
