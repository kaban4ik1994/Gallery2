using System.Web.Http;
using AutoMapper;
using Gallery.Models.Models;
using Gallery.Services.Interfaces;
using Gallety.Entities;

namespace Gallery.WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ITokenSevice _tokenSevice;
        private readonly IRoleService _roleService;
        public AccountController(IUserService userService, ITokenSevice tokenSevice, IRoleService roleService)
        {
            _userService = userService;
            _tokenSevice = tokenSevice;
            _roleService = roleService;
        }

        public IHttpActionResult Get(string email, string passwordHash)
        {
            var dbUser = _userService.GetUserByEmailAndPasswordHash(email, passwordHash);
            if (dbUser == null) return BadRequest("User not found!");
            var user = Mapper.Map<User>(dbUser);
            return Json(user);
        }

        public IHttpActionResult Put(User user)
        {
            var dbUser = Mapper.Map<DbUser>(user);
            _userService.CreateUser(dbUser);
            return Ok();
        }
    }
}
