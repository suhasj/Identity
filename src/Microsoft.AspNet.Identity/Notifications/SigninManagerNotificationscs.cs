using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public abstract class SigninManagerNotifications<TUser> : ISigninManagerNotifications<TUser> where TUser :class
    {
        public virtual Task OnIncorrectPasswordSignInAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnUserSigninAsync(TUser user, ClaimsIdentity userIdentity)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnValidateSecurityStampAsync(ClaimsIdentity userIdentity, string userId)
        {
            return Task.FromResult(0);
        }
    }
}