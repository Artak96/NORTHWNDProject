using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Operations;
using NorthWndCore.Abstractions;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.Entities;
using NorthWndDAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWndAPI.Middlewares;

namespace NorthWndAPI
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
              .AddCookie(options => 
              {
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
