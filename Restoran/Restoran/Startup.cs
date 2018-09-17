using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Restoran
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RestoranNewDb;Trusted_Connection=True;"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
            app.Run(async (context) => { await context.Response.WriteAsync($"<h1>Worked!!!</h1>"); });
        }
    }
}