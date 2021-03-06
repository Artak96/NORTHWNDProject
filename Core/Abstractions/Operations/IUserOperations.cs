using NorthWndCore.BusinessModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWndCore.Abstractions.Operations
{
    public interface IUserOperations
    {
        Task Logout(HttpContext context);
        Task Register(RegistrationModel model, HttpContext context);
        Task Login(LoginModel model, HttpContext context);
    }
}
