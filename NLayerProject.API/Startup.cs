using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLayerProject.Core.Repository;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWork;
using NLayerProject.Data.EntityFramework;
using NLayerProject.Data.Repositories;
using NLayerProject.Data.UnitOfWorks;
using NLayerProject.Service.Services;
using AutoMapper;
using NLayerProject.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using NLayerProject.API.DTOs;
using Microsoft.AspNetCore.Http;
using NLayerProject.API.Extensions;
using System.Net;

namespace NLayerProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                 {
                     o.MigrationsAssembly("NLayerProject.Data");
                 }
                );
            }
            );
            services.AddAutoMapper(typeof(Startup));//AutoMapper dependency injection ayarý

            services.AddScoped<NotFoundFilter>();//cons ta interface implemente edildiði için servislere eklendi.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //birkere oluþturur hep ilk oluþturduðu nesne örneðini kullanýr.
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options => { 
                options.SuppressModelStateInvalidFilter = true; //asp.net core filterlarý kontrol etmisin. Ben default olarak oluþturacðým
            });



      //      ServicePointManager.ServerCertificateValidationCallback +=
      //(sender, certificate, chain, errors) =>
      //{
      //    return true;
      //};



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();//extension custom method

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
