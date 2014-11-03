using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.AzureTableStorage;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.UserName);
                u.Timestamp("Timestamp", true);
                u.Table("IdentityUser");
            });

            builder.Entity<IdentityRole>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.Name);
                u.Timestamp("Timestamp", true);
                u.Table("IdentityRoles");
            });

            builder.Entity<IdentityRoleClaim>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.RoleId);
                u.Timestamp("Timestamp", true);
                u.Table("IdentityRoleClaims");
            });

            builder.Entity<IdentityUserClaim>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.UserId);
                u.Timestamp("Timestamp", true);
                u.Table("IdentityUserClaims");
            });

            builder.Entity<IdentityUserLogin>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.UserId, s => s.ProviderKey);
                u.Timestamp("Timestamp", true);
                u.Table("IdentityUserLogins");
            });

            builder.Entity<IdentityUserRole>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.UserId, s => s.RoleId);
                u.Timestamp("Timestamp", true);
                u.Table("IdentityUserRoles");
            });

           // base.OnModelCreating(builder);
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

            options.UseAzureTableStorage(configuration.Get("Data:IdentityNotificationConnection:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNotification>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.UserId, s => s.Id);
                u.Timestamp("Timestamp", true);
                u.Table("IdentityUserNotifications");
            });
        }
    }
}