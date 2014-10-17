using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Microsoft.AspNet.Identity
{
    public class UserManagerNotifications<TUser> : IUserManagerNotifications<TUser>  where TUser :class
    {
        private ILogger _logger;

        public UserManagerNotifications(ILoggerFactory loggerfactory)
        {
            _logger = loggerfactory.Create<UserManagerNotifications<TUser>>();
        }


        public Task OnChangePasswordFailureAsync(IdentityResult result, TUser user)
        {
            var identityUser = user as IdentityUser;
            _logger.WriteError(string.Format("User {0} failed to change password", identityUser.UserName));
            return Task.FromResult(0);
        }

        public Task OnChangePasswordSuccessAsync(TUser user)
        {
            var identityUser = user as IdentityUser;
            _logger.WriteInformation(string.Format("User {0} successfully change password", identityUser.UserName));
            return Task.FromResult(0);
        }

        public Task OnResetPasswordFailureAsync(IdentityResult result, TUser user)
        {
            var identityUser = user as IdentityUser;
            _logger.WriteError(string.Format("User {0} failed to reset password due to {1}", identityUser.UserName,string.Join(",",result.Errors)));
            return Task.FromResult(0);
        }

        public Task OnResetPasswordSuccessAsync(TUser user)
        {
            var identityUser = user as IdentityUser;
            _logger.WriteInformation(string.Format("User {0} successfully reset password", identityUser.UserName));
            return Task.FromResult(0);
        }

        public Task OnUserCreateAsync(TUser user)
        {
            var identityUser = user as IdentityUser;
            _logger.WriteInformation(string.Format("User {0} being created", identityUser.UserName));
            return Task.FromResult(0);
        }

        public Task OnUserUpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }
    }
}