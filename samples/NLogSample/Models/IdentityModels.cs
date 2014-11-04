using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.AzureTableStorage;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NLogSample.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        
        public ApplicationUser()
        {
            LockoutEnd = DateTimeOffset.UtcNow;
        }
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
              //  Database.EnsureDeleted();
                Database.EnsureCreated();
                _created = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           // MapModelsForATS(builder);

            base.OnModelCreating(builder);
        }

        private static void MapModelsForATS(ModelBuilder builder)
        {
            var entity = builder.Entity<ApplicationUser>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.UserName);
                u.Table("IdentityUsers");
            });

            entity.Metadata.RemoveProperty(entity.Metadata.Properties.Where(x => x.Name.Equals("LockoutEnd")).FirstOrDefault());

            builder.Entity<IdentityRole>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.Name);
                u.Table("IdentityRoles");
            });

            builder.Entity<IdentityRoleClaim<string>>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.RoleId);
                u.Table("IdentityRoleClaims");
            });

            builder.Entity<IdentityUserClaim<string>>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.Id, s => s.UserId);
                u.Table("IdentityUserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.UserId, s => s.ProviderKey);
                u.Table("IdentityUserLogins");
            });

            builder.Entity<IdentityUserRole<string>>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.UserId, s => s.RoleId);
                u.Table("IdentityUserRoles");
            });

            var notificationEntity = builder.Entity<UserNotification>().ForAzureTableStorage(u =>
            {
                u.PartitionAndRowKey(s => s.UserId, s=> s.RowKey);
                u.Table("IdentityUserNotifications");
            });
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
               // Database.EnsureDeleted();
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