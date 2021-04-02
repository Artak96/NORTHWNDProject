using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstractions;
using Core.Abstractions.Operations;
using Core.BusinessModels;
using Core.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NORTHWNDProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserOperations _userOperations;
        public UserController(IUserOperations userOperations)
        {
            _userOperations = userOperations;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                await _userOperations.Login(model, HttpContext);
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
                await _userOperations.Register(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userOperations.Logout(HttpContext);
            return Ok();
        }
        

        //[HttpGet("custom")]
        //[ClaimRequirement("role", "user")]
        //public async Task<IActionResult> CustomAction()
        //{
        //    await _userOperations.Logout(HttpContext);
        //    return Ok();
        //}
    }
}
