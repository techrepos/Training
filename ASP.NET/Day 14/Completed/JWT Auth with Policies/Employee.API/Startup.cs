using Employee.API.Handlers;
using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddDbContext<EmployeeContext>(opt =>
                opt.UseSqlServer(_configuration.GetConnectionString("DBConnection")));


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Read", policyOpt => policyOpt.AddRequirements(new PermissionRequirement("Read")));
                opt.AddPolicy("Exclusive", policyOpt => policyOpt.AddRequirements(new PermissionRequirement("Exclusive")));
                opt.AddPolicy("Add", policyOpt => policyOpt.AddRequirements(new PermissionRequirement("Add")));
                opt.AddPolicy("Delete", policyOpt => policyOpt.AddRequirements(new PermissionRequirement("Delete")));
                opt.AddPolicy("Update", policyOpt => policyOpt.AddRequirements(new PermissionRequirement("Update")));
            });


            services.AddSingleton<IAuthorizationHandler, CustomPermissionHandler>();


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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("SamplePolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
