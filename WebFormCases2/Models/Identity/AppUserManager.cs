﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormCases2.Models.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
        }
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager>options,
            IOwinContext context
            )
        {
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
     
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 3,
            //    RequireNonLetterOrDigit = false,
            //    RequireDigit = false,
            //    RequireLowercase = true,
            //    RequireUppercase = false,

            //};
            manager.PasswordValidator = new AppPasswordValidator() {
                RequiredLength=6,
                RequireLowercase=true,
                RequireDigit =true,
                RequireUppercase = true
            };


            return manager;
        }
    }
}