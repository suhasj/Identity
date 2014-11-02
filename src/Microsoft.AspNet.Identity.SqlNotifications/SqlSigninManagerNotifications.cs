using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public class SqlSigninManagerNotifications<TUser> :SigninManagerNotifications<TUser> where TUser :IdentityUser
    {
        private readonly INotificationFactory _notificationFactory;

        public SqlSigninManagerNotifications(INotificationFactory notificationFactory)
        {
            _notificationFactory = notificationFactory;
        }

        public override Task OnIncorrectPasswordSignInAsync(TUser user)
        {
            var notification = new UserNotification() { UserId = user.Id, ActivityTime = DateTimeOffset.UtcNow, Activity = "Login attempt with incorrect password" };

            return _notificationFactory.CreateAsync(notification);
        }

        public override Task OnUserSigninAsync(TUser user, ClaimsIdentity userIdentity)
        {
            var notification = new UserNotification() { UserId = user.Id, ActivityTime = DateTimeOffset.UtcNow, Activity = "User login success" };

            return _notificationFactory.CreateAsync(notification);
        }

        public override Task OnValidateSecurityStampAsync(ClaimsIdentity userIdentity, string userId)
        {
            return base.OnValidateSecurityStampAsync(userIdentity, userId);
        }
    }
}