using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    public static class EntityFrameworkNotificationBuilderExtensions
    {
        public static IdentityBuilder<IdentityUser, IdentityRole> AddEntityFrameworkNotifications<TContext>(this IdentityBuilder<IdentityUser, IdentityRole> builder)
            where TContext : DbContext
        {
            return AddEntityFrameworkNotifications<TContext,IdentityUser>(builder);
        }

        public static IdentityBuilder<TUser, IdentityRole> AddEntityFrameworkNotifications<TContext, TUser>(this IdentityBuilder<TUser, IdentityRole> builder)
            where TUser : IdentityUser, new()
            where TContext : DbContext
        {
            builder.Services.AddScoped<INotificationFactory, EntityFrameworkNotificationFactory<TContext>>();
            builder.Services.AddScoped<IUserManagerNotifications<TUser>, SqlUserManagerNotifications<TUser>>();
            builder.Services.AddScoped<ISigninManagerNotifications<TUser>, SqlSigninManagerNotifications<TUser>>();

            return builder;
        }
    }
}