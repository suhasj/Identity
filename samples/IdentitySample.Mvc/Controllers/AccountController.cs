using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using IdentitySample.Models;
using System.Security.Principal;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public SignInManager<ApplicationUser> SignInManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var signInStatus = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
                switch (signInStatus)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl);
                    case SignInStatus.LockedOut:
                        ModelState.AddModelError("", "User is locked out, try again later.");
                        return View(model);
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid username or password.");
                        return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Manage
        public IActionResult Manage(ManageMessageId? message = null)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Manage(ManageUserViewModel model)
        {
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var result = await UserManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var failure in result.Failures)
            {
                ModelState.AddModelError("", ApplicationErrors.GetDescription(failure));
            }
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await UserManager.FindByIdAsync(Context.User.Identity.GetUserId());
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public static class ApplicationErrors
        {
            public static string GetDescription(IdentityFailure failure)
            {
                switch (failure)
                {
                    case IdentityFailure.DuplicateUserName:
                    case IdentityFailure.DuplicateEmail:
                    case IdentityFailure.DuplicateRoleName:
                    case IdentityFailure.UserValidationFailed:
                    case IdentityFailure.UserNameTooShort:
                    case IdentityFailure.RoleNameTooShort:
                    case IdentityFailure.UserNameInvalid:
                    case IdentityFailure.EmailInvalid:
                    case IdentityFailure.UserAlreadyInRole:
                    case IdentityFailure.UserAlreadyHasPassword:
                    case IdentityFailure.LoginAlreadyAssociated:
                    case IdentityFailure.UserNotInRole:
                    case IdentityFailure.LockoutForUserNotEnabled:
                    case IdentityFailure.RoleValidationFailed:
                    case IdentityFailure.InvalidEmail:
                    case IdentityFailure.InvalidToken:
                    case IdentityFailure.PasswordMismatch:
                    case IdentityFailure.PasswordRequiresDigit:
                    case IdentityFailure.PasswordRequiresLower:
                    case IdentityFailure.PasswordRequiresUpper:
                    case IdentityFailure.PasswordTooShort:
                    case IdentityFailure.PasswordRequiresNonLetterAndDigit:
                    case IdentityFailure.Unknown:
                    default:
                        return failure.ToString();
                }
            }
        }

        #endregion
    }
}