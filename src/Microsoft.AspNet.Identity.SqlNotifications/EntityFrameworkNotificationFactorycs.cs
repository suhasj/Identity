using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Microsoft.AspNet.Identity
{
    public class EntityFrameworkNotificationFactory : INotificationFactory
    {
        private readonly DbContext _notificationContext;

        private DbSet<UserNotification> UserNotifications { get { return _notificationContext.Set<UserNotification>(); } }

        public EntityFrameworkNotificationFactory(DbContext context)
        {
            _notificationContext = context;
        }
        public Task CreateAsync(UserNotification userNotification)
        {
            UserNotifications.Add(userNotification);

            return _notificationContext.SaveChangesAsync();
        }

        public Task DeleteAsync(UserNotification userNotification)
        {
            UserNotifications.Remove(userNotification);

            return _notificationContext.SaveChangesAsync();
        }

        public IEnumerable<UserNotification> GetNotificationsForUser(string userId)
        {
            return UserNotifications.Where(x => x.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase)).Select(x => x);
        }

        public UserNotification GetNotificaton(int id)
        {
            return UserNotifications.Where(x => x.Id == id).FirstOrDefault();
        }

        public Task UpdateAsync(UserNotification userNotification)
        {
            UserNotifications.Update(userNotification);

            return _notificationContext.SaveChangesAsync();
        }
    }
}