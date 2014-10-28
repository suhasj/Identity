using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.ConfigurationModel;

namespace NLogSample.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static bool _created = false;
        
        public ApplicationDbContext() : base()
        {            
            // Create the database and schema if it doesn't exist
            // This is a temporary workaround to create database until Entity Framework database migrations 
            // are supported in ASP.NET vNext
            if (!_created)
            {
                Database.EnsureCreated();
                _created = true;
            }
        }
    }

    public class SampleNotificationContext : NotificationContext
    {
        private static bool _created = false;

        public SampleNotificationContext()
        {
            // Create the database and schema if it doesn't exist
            // This is a temporary workaround to create database until Entity Framework database migrations 
            // are supported in ASP.NET vNext
            if (!_created)
            {
                Database.EnsureCreated();
                _created = true;
            }
        }

        protected override void OnConfiguring(DbContextOptions options)
        {
            var configuration = new Configuration();
            configuration.AddJsonFile("config.json");
            configuration.AddEnvironmentVariables();

            options.UseSqlServer(configuration.Get("Data:IdentityNotificationConnection:ConnectionString"));
        }
    }
}