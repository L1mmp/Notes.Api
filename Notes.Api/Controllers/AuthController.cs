using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.Domian.Models;
using Notes.Domian.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        /// <summary>
        /// Login 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            var response = _authService.Login(user);


            return Ok(response);

        }
        /// <summary>
        /// Registration new user
        /// </summary>
        /// <param name="user"></param>

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(User user)
        {
            var response = await _authService.Register(user);

            if (response == null)
            {
                return BadRequest(new { message = "Didn`t register!" });
            }

            return Ok(response);
        }

    }
}
