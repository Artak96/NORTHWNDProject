using NorthWndCore.Abstractions;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using NorthWndCore.Entities;
using NorthWndCore.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operations
{
    public class UserOperations : IUserOperations
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<UserOperations> _logger;
        public UserOperations(IRepositoryManager repositoryManager,ILogger<UserOperations> logger)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        public async Task Login(LoginModel model, HttpContext context)
        {
            _logger.LogInformation("UserOperations --- Login method started");
            User user = _repositoryManager.Users.GetSingle(u => u.Email == model.Email && u.Password == model.Password) ??
                throw new LogicException("Wrong passwor or Emile");
            await Authenticate(model.Email, context);
            _logger.LogInformation("UserOperations --- Login method finished");
        }

        public async Task Logout(HttpContext context)
        {
            _logger.LogInformation("UserOperations --- Logout method started");
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("UserOperations --- Logout method finished");
        }

        public async Task Register(RegistrationModel model, HttpContext context)
        {
            _logger.LogInformation("UserOperations --- Register method started");
            User user = _repositoryManager.Users.GetSingle(u => u.Email == model.Email);
            if (user==null)
            {
                _repositoryManager.Users.Add(new User
                {
                    Email = model.Email,
                    Password=model.Password
                });
                await _repositoryManager.SaveChangesAsync();

                await Authenticate(model.Email, context);

            }
            else
            {
                throw new LogicException("User already exist");
            }
            _logger.LogInformation("UserOperations --- Register method finished");
        }


        private async Task Authenticate(string userName, HttpContext context)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
            };
            await context.SignOutAsync();
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
