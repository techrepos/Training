using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Infrastructure.Repositories;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace Employee.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: "SamplePolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44369");
                       // WithMethods("POST")  
                       // .WithHeaders(HeaderNames.ContentType, "x-check-header"); ;
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("SamplePolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
