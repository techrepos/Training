using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace Employee.API
{
   
    public class Startup
    {

        public IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers();
            // allow a client to call you without specifying an api version
            // since we haven't configured it otherwise, the assumed api version will be 1.0
            services.AddApiVersioning(options => options.ApiVersionReader = new HeaderApiVersionReader("x-ms-version"));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddDbContext<EmployeeContext>(opt =>
                opt.UseSqlServer(_configuration.GetConnectionString("DBConnection")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/error");
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("SamplePolicy");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
              
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
                c.RoutePrefix = "docs";
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
