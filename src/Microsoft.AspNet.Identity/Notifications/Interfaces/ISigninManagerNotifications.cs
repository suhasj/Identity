using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public interface ISigninManagerNotifications<TUser> where TUser :class
    {
        Task OnUserSigninAsync(TUser user, ClaimsIdentity userIdentity);

        Task OnValidateSecurityStampAsync(ClaimsIdentity userIdentity, string userId);

        Task OnIncorrectPasswordSignInAsync(TUser user);
    }
}