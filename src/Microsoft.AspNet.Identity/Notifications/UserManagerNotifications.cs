﻿﻿using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public abstract class UserManagerNotifications<TUser> : IUserManagerNotifications<TUser> where TUser : class
    {
        public virtual Task OnAddClaimAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnAddLoginAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnAddPasswordFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnAddPasswordSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnAddToRoleAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnChangePasswordFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnChangePasswordSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnChangePhoneNumberAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnChangePhoneNumberSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnConfirmEmailFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnConfirmEmailSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnCreateUserFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnCreateUserSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnDeleteUserFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnDeleteUserSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnRemoveClaimAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnRemoveLoginAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnRemovePasswordAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnRemoveRoleAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnResetPasswordFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnResetPasswordSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnSetEmailAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnSetLockoutEndDateFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnSetLockoutEndDateSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnSetPhoneNumberAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnUpdateUserFailureAsync(IdentityResult result, TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnUpdateUserSuccessAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnUserAccessFailedAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnVerifyTwoFactorTokenAsync(bool result, TUser user)
        {
            return Task.FromResult(0);
        }
    }
}