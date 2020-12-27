using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderService.Api.Database;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Repositories.Mock;
using Microsoft.EntityFrameworkCore;
using OrderService.Api.Repositories;
using Microsoft.AspNetCore.Identity;
using OrderService.Api.Database.Seed;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using OrderService.Api.Service.Interface;
using OrderService.Api.Service;

namespace OrderService.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<OSContext>(options =>
            {
                options.UseSqlServer(this.Configuration["Data:OrderServiceData:ConnectionString"]);
            });

            services.AddDbContext<OSIdentityContext>(options =>
            {
                options.UseSqlServer(this.Configuration["Data:OrderServiceIdentity:ConnectionString"]);
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<OSIdentityContext>();

            /*services.AddTransient<ICustomerRepository, CustomerFakeRepository>();             
            services.AddTransient<IEmployeeRepository, EmployeeFakeRepository>();
            services.AddTransient<IOrderRepository, OrderFakeRepository>();*/

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IOrderService, OsService>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "Ordem de Serviço - API",
                    Version = "v1",
                    Description = "Documentação da API de Ordens de Serviço",
                    Contact = new OpenApiContact
                    {
                        Name = "Julio Murta",
                        Url = new Uri("https://github.com/juliomurta")
                    }
                });

                string appPath = PlatformServices.Default.Application.ApplicationBasePath;
                string appName = PlatformServices.Default.Application.ApplicationName;
                string xmlDoc = Path.Combine(appPath, $"{appName}.xml");

                x.IncludeXmlComments(xmlDoc);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordens de Serviços");
                });
            }

            app.UseAuthentication();
            app.UseMvc();

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
