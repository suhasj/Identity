using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public interface INotificationFactory
    {
        Task CreateAsync(UserNotification userNotification);

        UserNotification GetNotificaton(int id);

        IEnumerable<UserNotification> GetNotificationsForUser(string userId);

        Task UpdateAsync(UserNotification userNotification);

        Task DeleteAsync(UserNotification userNotification);
    }
}