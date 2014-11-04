using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Microsoft.AspNet.Identity
{
    public class NotificationContext: DbContext
    {
        public NotificationContext()
        {

        }

        public DbSet<UserNotification> UserNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNotification>(b =>
            {
                b.ForRelational().Table("UserNotifications");
            });

        }
    }
}