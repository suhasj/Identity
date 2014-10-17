using Microsoft.AspNet.Http;
using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public interface IUserManagerNotifications<TUser>
    {
        // TODO: Take HttpContext as a argument ?
        Task OnUserCreateAsync(TUser user);

        Task OnUserUpdateAsync(TUser user);

        Task OnChangePasswordSuccessAsync(TUser user);

        Task OnChangePasswordFailureAsync(IdentityResult result, TUser user);

        Task OnResetPasswordSuccessAsync(TUser user);

        Task OnResetPasswordFailureAsync(IdentityResult result, TUser user);
    }
}