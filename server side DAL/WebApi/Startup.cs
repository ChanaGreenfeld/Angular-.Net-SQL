using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using BLL;
using Microsoft.EntityFrameworkCore;



namespace WebApi
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
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            //});
            //ADD CORS
            services.AddCors(p => p.AddPolicy("AlowAll", option =>
            {
                option.AllowAnyMethod();
                option.AllowAnyHeader();
                option.AllowAnyOrigin();
            }));


            
                services.AddScoped(typeof(ICategoryDAL), typeof(CategoryDAL));
                services.AddScoped(typeof(ICategoryBLL), typeof(CategoryBLL));
                services.AddScoped(typeof(IToysDAL), typeof(ToysDAL));
                services.AddScoped(typeof(IToysBLL), typeof(ToysBLL));
                services.AddScoped(typeof(IUsersDAL), typeof(UsersDAL));
                services.AddScoped(typeof(IUsersBLL), typeof(UsersBLL));
                services.AddScoped(typeof(IBuyingDAL), typeof(BuingDAL));
                services.AddScoped(typeof(IBuingBLL), typeof(BuingBLL));
                services.AddScoped(typeof(IBuingDetailsDAL), typeof(BuingDetailsDAL));
                services.AddScoped(typeof(IBuingDetailsBLL), typeof(BuingDetailsBLL));
                services.AddDbContext<DAL.Models.Toys_dbContext>(x => x.UseSqlServer("Server=.;Database=Toys_db;Trusted_Connection=true"));

        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseCors("AlowAll");
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


    