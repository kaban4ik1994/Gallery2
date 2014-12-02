using System;
using System.Runtime.CompilerServices;
using System.Web.Http;
using AutoMapper;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
using Newtonsoft.Json;

namespace Gallery.WebAPI.Controllers
{
    public class ImageController : ApiController
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public IHttpActionResult Get(string command, long id, int minHeight,
            int minWidth, int maxHeight, int maxWidth)
        {
            if (String.Equals(command, "PictureImage", StringComparison.CurrentCultureIgnoreCase))
            {
                var dbImage = _imageService.GetImageByPictureId(id, minHeight, minWidth, maxHeight, maxWidth);
                var image = Mapper.Map<Image>(dbImage);
                return Json(image, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            
            return BadRequest("Command not found!");
        }
    }
}