using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Operations;
using Core.Abstractions;
using Core.Abstractions.Operations;
using Core.Entities;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NORTHWNDProject.Middlewares;

namespace NORTHWNDProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NORTHWNDContext>(x =>
            {
                x.UseSqlServer("Server=LAPTOP-5FTFC6HC;Database=NORTHWND;Trusted_Connection=True;");
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options => //CookieAuthenticationOptions
              {
                  //   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
              });
            services.AddControllers();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IUserOperations, UserOperations>();
            services.AddScoped<IEmployeeOperations, EmployeeOperations>();
            services.AddScoped<IOrderOperations, OrderOperations>();
            services.AddScoped<IProductOperations, ProductOperations>();
            services.AddScoped<ISupplierOperations, SupplierOperations>();
            services.AddScoped<IOrderDetailOperations, OrderDetailOperations>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
