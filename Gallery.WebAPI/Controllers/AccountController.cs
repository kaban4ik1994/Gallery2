using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gallery.Services.Interfaces;
using Gallety.Entities;
using Ninject;

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
            var user = _userService.GetUserByEmailAndPasswordHash(email, passwordHash);
            if (user == null) return BadRequest("User not found!");
            return Json(user);
        }

        public IHttpActionResult Put(string userName, string email, string passwordHash)
        {
           
            var user = new DbUser
            {
                Email = email,
                UserName = userName,
                PasswordHash = passwordHash,
                UserRoleId = 1
            };
            _userService.CreateUser(user);
            return Ok();
        }
    }
}
