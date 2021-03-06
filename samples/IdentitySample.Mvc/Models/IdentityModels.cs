﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.SqlServer;
using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;

namespace IdentitySample.Models
{
    public class ApplicationUser : IdentityUser { }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(IServiceProvider serviceProvider, IOptionsAccessor<IdentityDbContextOptions> optionsAccessor)
                   : base(serviceProvider, optionsAccessor.Options)
        {
        }
    }

    public class IdentityDbContextOptions : DbContextOptions
    {
        public string DefaultAdminUserName { get; set; }

        public string DefaultAdminPassword { get; set; }
    }
}