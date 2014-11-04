using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public class SqlUserManagerNotifications<TUser> : UserManagerNotifications<TUser> where TUser :IdentityUser
    {
        private readonly INotificationFactory _notificationFactory;

        public SqlUserManagerNotifications(INotificationFactory notificationFactory)
        {
            _notificationFactory = notificationFactory;
        }

        public override Task OnChangePasswordFailureAsync(IdentityResult result, TUser user)
        {
            var notification = new UserNotification() { UserId = user.Id, ActivityTime = DateTime.UtcNow, Activity = "Password change attempt failed" };

            return _notificationFactory.CreateAsync(notification);
        }

        public override Task OnChangePasswordSuccessAsync(TUser user)
        {
            var notification = new UserNotification() { UserId = user.Id, ActivityTime = DateTime.UtcNow, Activity = "Password changed" };

            return _notificationFactory.CreateAsync(notification);
        }

        public override Task OnCreateUserFailureAsync(IdentityResult result, TUser user)
        {
            var notification = new UserNotification() { UserId = user.Id, ActivityTime = DateTime.UtcNow, Activity = "Creating user failed" };

            return _notificationFactory.CreateAsync(notification);
        }

        public override Task OnCreateUserSuccessAsync(TUser user)
        {
            var notification = new UserNotification() { UserId = user.Id, ActivityTime = DateTime.UtcNow, Activity = "Password changed" };

            return _notificationFactory.CreateAsync(notification);
        }
    }
}