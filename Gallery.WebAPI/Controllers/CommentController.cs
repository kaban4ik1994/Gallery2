using System;
using System.Web.Http;
using AutoMapper;
using Gallery.Entities;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
using Newtonsoft.Json;

namespace Gallery.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPut]
        public IHttpActionResult Put(Comment comment)
        {
            
            var dbComment = Mapper.Map<DbComment>(comment);
            _commentService.CreateComment(dbComment);
            return Json(Mapper.Map<Comment>(dbComment), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
