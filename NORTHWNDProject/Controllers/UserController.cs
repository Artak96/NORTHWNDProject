using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NorthWndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserOperations _user;
        public UserController(IUserOperations user)
        {
            _user = user;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                await _user.Login(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Registr([FromBody] RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                await _user.Register(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _user.Logout(HttpContext);
            return Ok();
        }
    }
}
