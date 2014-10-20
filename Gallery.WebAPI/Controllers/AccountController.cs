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
        public AccountController(IUserService userService, ITokenSevice tokenSevice)
        {
             _userService = userService;
            _tokenSevice = tokenSevice;
        }

        public IHttpActionResult Get(string email, string passwordHash)
        {
            var user = _userService.GetUserByEmailAndPasswordHash(email, passwordHash);
            if (user == null) return BadRequest("User not found!");
            return Ok(user);
        }
    }
}
