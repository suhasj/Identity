// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Security.Cookies;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Startup extensions
    /// </summary>
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseIdentity(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            //var options = app.ApplicationServices.GetService<IOptionsAccessor<IdentityOptions>>().Options;
            //app.SetDefaultSignInAsAuthenticationType(options.ExternalCookie.AuthenticationType);
            app.UseCookieAuthentication(IdentityOptions.ExternalCookieAuthenticationType);
            app.UseCookieAuthentication(IdentityOptions.ApplicationCookieAuthenticationType);
            app.UseCookieAuthentication(IdentityOptions.TwoFactorRememberMeCookieAuthenticationType);
            app.UseCookieAuthentication(IdentityOptions.TwoFactorUserIdCookieAuthenticationType);
            app.UseCookieAuthentication(IdentityOptions.ApplicationCookieAuthenticationType);
            return app;
        }
    }
}