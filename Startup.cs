using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using KeebClack.API.models;

namespace KeebClack.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            // In memory database stuff for UserDbContext
            services.AddDbContext<UserDbContext>(options=>options.UseInMemoryDatabase("UserDB"));
            services.AddScoped<UserDbContext>();

            // In memory database stuff for KeyboardDbContext
            services.AddDbContext<KeyboardDbContext>(options => options.UseInMemoryDatabase("KeyboardDB"));
            services.AddScoped<KeyboardDbContext>();

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // *NOTE* local: update env in IDE
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseRouting();
            app.UseMvc();
        }
    }
}
