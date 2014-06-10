// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Xunit;

namespace Microsoft.AspNet.Identity.Test
{
    public class IdentityResourcesTest
    {
        [Theory]
        [InlineData(IdentityErrorCode.DefaultError, "An unknown failure has occured.")]
        [InlineData(IdentityErrorCode.DuplicateEmail, "Email '{0}' is already taken.")]
        //[InlineData(IdentityErrorCode.DuplicateName, "Email '{0}' is already taken.")]
        //[InlineData(IdentityErrorCode.ExternalLoginExists, "Email '{0}' is already taken.")]
        //[InlineData(IdentityErrorCode.InvalidEmail, "Email '{0}' is already taken.")]
        public void VerifyDefaultErrorStrings(IdentityErrorCode code, string value)
        {
            var manager = new IdentityResourceManager();
            Assert.Equal(value, manager.GetString(code));
        }
    }
}