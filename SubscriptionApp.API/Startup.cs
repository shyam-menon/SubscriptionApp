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
using SubscriptionApp.API.Data;

namespace SubscriptionApp.API
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
            services.AddDbContext<DataContext>(x => x.UseSqlite
            (Configuration.GetConnectionString("DefaultConnection")));
            //.NET Core 3.0 took out the AddMVC() to strip away part not needed for Web API 
            services.AddControllers();
            //Add the CORS service
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Attempts to redirect any HTTP to HTTPS. Not needed as HTTPS is turned off
            //app.UseHttpsRedirection();

            app.UseRouting();

            //Header needs to sent back from the API server so that the client knows it can trust it
            //This needs to be after routing has been setup but before setting up authorization and
            //UseEndpoints call. This should not be used in production as the security is lax here
            //This adds "Access-Control-Allow-Origin header to the response and so the client will
            //accept this.
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
