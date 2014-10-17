using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Security.Cookies;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using NLogSample.Models;
using Microsoft.Framework.Logging;

namespace NLogSample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Setup configuration sources
            var configuration = new Configuration();
            configuration.AddJsonFile("config.json");
            configuration.AddEnvironmentVariables();

            var factory = new LoggerFactory();
            factory.AddNLog(new global::NLog.LogFactory());

            // Set up application services
            app.UseServices(services =>
            {
                // Add EF services to the services container
                services.AddEntityFramework()
                    .AddSqlServer().AddDbContext<ApplicationDbContext>(options=>
                    {
                        options.UseSqlServer(configuration.Get("Data:DefaultConnection:ConnectionString"));
                    });
                
                // Add Identity services to the services container
                services.AddDefaultIdentity<ApplicationDbContext,ApplicationUser, IdentityRole>(configuration);

                // Add MVC services to the services container
                services.AddMvc();

                services.AddInstance<ILoggerFactory>(factory);
            });

            // Enable Browser Link support
            app.UseBrowserLink();

            // Add static files to the request pipeline
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline
            app.UseIdentity();

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default", 
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{id?}");
            });
        }
    }
}
