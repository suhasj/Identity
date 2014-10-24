using Microsoft.AspNet.Http;
using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public interface IUserManagerNotifications<TUser>
    {
        // TODO: Take HttpContext as a argument ?
        Task OnCreateUserSuccessAsync(TUser user);
        Task OnCreateUserFailureAsync(IdentityResult result,TUser user);

        Task OnUpdateUserSuccessAsync(TUser user);
        Task OnUpdateUserFailureAsync(IdentityResult result, TUser user);

        Task OnChangePasswordSuccessAsync(TUser user);
        Task OnChangePasswordFailureAsync(IdentityResult result, TUser user);

        Task OnResetPasswordSuccessAsync(TUser user);
        Task OnResetPasswordFailureAsync(IdentityResult result, TUser user);

        Task OnDeleteUserSuccessAsync(TUser user);
        Task OnDeleteUserFailureAsync(IdentityResult result, TUser user);

        Task OnAddPasswordSuccessAsync(TUser user);
        Task OnAddPasswordFailureAsync(IdentityResult result, TUser user);

        Task OnRemovePasswordAsync(TUser user);

        Task OnRemoveLoginAsync(TUser user);

        Task OnAddLoginAsync(TUser user);

        Task OnAddClaimAsync(TUser user);

        Task OnRemoveClaimAsync(TUser user);

        Task OnAddToRoleAsync(TUser user);

        Task OnRemoveRoleAsync(TUser user);

        Task OnSetEmailAsync(TUser user);

        Task OnSetPhoneNumberAsync(TUser user);

        Task OnConfirmEmailSuccessAsync(TUser user);
        Task OnConfirmEmailFailureAsync(IdentityResult result, TUser user);

        Task OnChangePhoneNumberSuccessAsync(TUser user);
        Task OnChangePhoneNumberAsync(IdentityResult result, TUser user);

        Task OnVerifyTwoFactorTokenAsync(bool result, TUser user);

        Task OnSetLockoutEndDateSuccessAsync(TUser user);
        Task OnSetLockoutEndDateFailureAsync(IdentityResult result, TUser user);

        Task OnUserAccessFailedAsync(TUser user);
    }
}