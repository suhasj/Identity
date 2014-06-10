// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNet.Identity
{
    /// <summary>
    ///     Manages resource strings
    /// </summary>
    public interface IIdentityResourceManager<TResourceCode>
    {
        string GetString(TResourceCode code);
    }

    public class IdentityResourceManager : IIdentityResourceManager<IdentityErrorCode>
    {
        public virtual string GetString(IdentityErrorCode code)
        {
            switch (code)
            {
                // TODO: add rest
                case IdentityErrorCode.DuplicateEmail:
                    return Resources.DuplicateEmail;
                case IdentityErrorCode.UserNameTooShort:
                    return Resources.UserNameTooShort;
                case IdentityErrorCode.DefaultError:
                default:
                    return Resources.DefaultError;
            }
        }
    }

    public enum IdentityErrorCode
    {
        DefaultError,
        DuplicateEmail,
        DuplicateName,
        ExternalLoginExists,
        InvalidEmail,
        InvalidToken,
        InvalidUserName,
        LockoutNotEnabled,
        PasswordMismatch,
        PasswordRequireDigit,
        PasswordRequireLower,
        PasswordRequireNonLetterOrDigit,
        PasswordRequireUpper,
        PasswordTooShort,
        UserNameTooShort,
        RoleNotFound,
        StoreNotIQueryableRoleStore,
        StoreNotIQueryableUserStore,
        StoreNotIUserClaimStore,
        StoreNotIUserEmailStore,
        StoreNotIUserLockoutStore,
        StoreNotIUserLoginStore,
        StoreNotIUserPasswordStore,
        StoreNotIUserPhoneNumberStore,
        StoreNotIUserRoleStore,
        StoreNotIUserSecurityStampStore,
        StoreNotIUserTwoFactorStore,
        UserAlreadyHasPassword,
        UserAlreadyInRole,
        UserIdNotFound,
        UserNameNotFound,
        UserNotInRole,
    }

    public class EntityIdentityResourceManager : IIdentityResourceManager<EntityIdentityErrorCode>
    {
        public string GetString(EntityIdentityErrorCode code)
        {
            throw new NotImplementedException();
        }
    }

    public enum EntityIdentityErrorCode { }

    //public static class IdentityStrings
    //{
    //    public static readonly string DefaultError = "DefaultError";
    //    public static readonly string DuplicateEmail = "DuplicateEmail";
    //    public static readonly string DuplicateName = "";
    //    public static readonly string ExternalLoginExists = "";
    //    public static readonly string InvalidEmail = "";
    //    public static readonly string InvalidToken = "";
    //    public static readonly string InvalidUserName = "";
    //    public static readonly string LockoutNotEnabled = "";
    //    public static readonly string PasswordMismatch = "";
    //    public static readonly string PasswordRequireDigit = "";
    //    public static readonly string PasswordRequireLower = "";
    //    public static readonly string PasswordRequireNonLetterOrDigit = "";
    //    public static readonly string PasswordRequireUpper = "";
    //    public static readonly string PasswordTooShort = "";
    //    public static readonly string RoleNotFound = "";
    //    public static readonly string StoreNotIQueryableRoleStore = "";
    //    public static readonly string StoreNotIQueryableUserStore = "";
    //    public static readonly string StoreNotIUserClaimStore = "";
    //    public static readonly string StoreNotIUserEmailStore = "";
    //    public static readonly string StoreNotIUserLockoutStore = "";
    //    public static readonly string StoreNotIUserLoginStore = "";
    //    public static readonly string StoreNotIUserPasswordStore = "";
    //    public static readonly string StoreNotIUserPhoneNumberStore = "";
    //    public static readonly string StoreNotIUserRoleStore = "";
    //    public static readonly string StoreNotIUserSecurityStampStore = "";
    //    public static readonly string StoreNotIUserTwoFactorStore = "";
    //    public static readonly string UserAlreadyHasPassword = "";
    //    public static readonly string UserAlreadyInRole = "";
    //    public static readonly string UserIdNotFound = "UserIdNotFound";
    //    public static readonly string UserNameNotFound = "UserNameNotFound";
    //    public static readonly string UserNotInRole = "UserNotInRole";
    //}

}