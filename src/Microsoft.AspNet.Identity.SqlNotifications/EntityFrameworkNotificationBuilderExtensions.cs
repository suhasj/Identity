using Microsoft.AspNet.Identity;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    public static class EntityFrameworkNotificationBuilderExtensions
    {
        public static IdentityBuilder<IdentityUser, IdentityRole> AddEntityFrameworkNotifications<TContext>(this IdentityBuilder<IdentityUser, IdentityRole> builder)
            where TContext :NotificationContext
        {
            return AddEntityFrameworkNotifications<TContext,IdentityUser>(builder);
        }

        public static IdentityBuilder<TUser, IdentityRole> AddEntityFrameworkNotifications<TContext, TUser>(this IdentityBuilder<TUser, IdentityRole> builder)
            where TUser : IdentityUser, new()
            where TContext : NotificationContext
        {
            builder.Services.AddScoped<TContext>();
            builder.Services.AddScoped<INotificationFactory, EntityFrameworkNotificationFactory<TContext>>();
            builder.Services.AddScoped<IUserManagerNotifications<TUser>, SqlUserManagerNotifications<TUser>>();
            builder.Services.AddScoped<ISigninManagerNotifications<TUser>, SqlSigninManagerNotifications<TUser>>();

            return builder;
        }
    }
}