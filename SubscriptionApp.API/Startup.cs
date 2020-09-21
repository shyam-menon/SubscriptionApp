using System.Net;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SubscriptionApp.API.Data;
using SubscriptionApp.API.Data.LinqToDto;
using SubscriptionApp.API.Data.LinqToSql;
using SubscriptionApp.API.Helpers;
using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.Categories;
using SubscriptionApp.API.Models.PseudoSkus;
using SubscriptionApp.API.Models.Subscriptions;
using SubscriptionApp.API.Services;
using SubscriptionApp.API.Services.Implementations;
using SubscriptionApp.API.Services.Interfaces.PseudoSkuCatalogService;
using SubscriptionApp.API.Services.Interfaces.SubscriptionService;

namespace SubscriptionApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => {
                x.UseLazyLoadingProxies();
                x.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
             services.AddDbContext<DataContext>(x => {
                x.UseLazyLoadingProxies();
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite
            (Configuration.GetConnectionString("DefaultConnection")));
            //.NET Core 3.0 took out the AddMVC() to strip away part not needed for Web API 
            //Add Newtonsoft JSON instead of System.Text.JSON as part of .Net core 3
            services.AddControllers().AddNewtonsoftJson(opt => 
            {
                opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            //Add the CORS service to prevent exception in client as browser tries to prevent web page  
            //from making ajax requests to another domain.This restriction is called the same-origin 
            //policy and prevents a malicious site from reading sensitive data from another site.
            services.AddCors();
            
            //Add the Auth repository as scoped (once per request) instead of singleton or transient
            //It will now be available in the controllers
            services.AddScoped<IAuthRepository, AuthRepository>();            
            
            //Add the repositories
            services.AddScoped<IGenericRepository, CommonRepository>();
            services.AddScoped<IUserRepository, CommonRepository>();
            services.AddScoped<IPseudoSkuTitleRepository,PseudoSkuTitleRepository>();
            services.AddScoped<IPseudoSkuRepository,PseudoSkuRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ISubscriptionRepository,SubscriptionRepository>();


            //Add the services
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IPseudoSkuCatalogService, PseudoSkuCatalogService>();
            services.AddScoped<ISubscriptionService, SubscriptionService> ();

            //Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Add automapper. To get over ambiguous reference, point it to an assembly that
            //the specified type
            services.AddAutoMapper(typeof(CommonRepository).Assembly);

            //Add authentication as a service and which type of authentication
            //The security key in appsettings.JSON will be used as the key to validate the token
            //On production the token would be sent over HTTPS.
            //The appsettings.json is either not checked into source control OR
            //Use dotnet user-secrets which will add a "UserSecretsId" in csproj file which is used in dev
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                                .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Set up global exception handler in production mode
            //Extension method adds the application error header and the CORS header when exception occurs
            //so that Angular client can handle this
            else
            {
                app.UseExceptionHandler(builder => {
                    builder.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if(error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    }); 
                });

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

            //Setup authentication and authorization using the method configured in Configure services.
            //JWT in this case
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
