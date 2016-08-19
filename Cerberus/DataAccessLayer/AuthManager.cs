using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Cerberus.Controllers;
using Microsoft.AspNet.Identity;

namespace Cerberus.DataAccessLayer
{
    public class AuthManager
    {
        private ApplicationDbContext identity_context = new ApplicationDbContext();
        
        public void UpdataMainRoles()
        {
            ApplicationUser user = null;
            ApplicationUser super_user = null;

            //Create SuperUser role if not exists
            if (!this.identity_context.Roles.Any(x => x.Name == "SuperUser"))
            {
                this.identity_context.Roles.Add(new IdentityRole("SuperUser"));
            }

            //Create standard User role is not exists
            if (!this.identity_context.Roles.Any(x => x.Name == "User"))
            {
                this.identity_context.Roles.Add(new IdentityRole("User"));
            }

            //Create SuperUser if not exists
            if (!this.identity_context.Users.Any(x => x.Email == "superuser@cerberus.com"))
            {
                super_user = new ApplicationUser
                {
                    Email = "superuser@cerberus.com",
                    EmailConfirmed = true,
                    PasswordHash = "AIYcOCGn3U+ZYik5IWX4L+iPG2IA9Bc2kjfcvld4nrYc3obT/vlUajIoFLAeE1z/OQ==",
                    SecurityStamp = "90f28a31-e788-43cf-ae5b-8a16336d12f2",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEndDateUtc = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "superuser@cerberus.com",
                };

                this.identity_context.Users.Add(super_user);
            }
            else
            {
                super_user = this.identity_context.Users.Where(x => x.Email == "superuser@cerberus.com").First();
            }

            //Create standard User if not exists
            if(!this.identity_context.Users.Any(x => x.Email == "user@cerberus.com"))
            {
                user = new ApplicationUser
                {
                    Email = "user@cerberus.com",
                    EmailConfirmed = true,
                    PasswordHash = "AMmB9gaz4iHDS0Yab/pLD2BY0LdvJjOZWUJHw6BEaur0GnFPG93tVxbE46E710Ouwg==",
                    SecurityStamp = "9bf859b0-1e2f-4e44-a1ab-b95dbc472841",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEndDateUtc = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "user@cerberus.com"
                };

                this.identity_context.Users.Add(user);
            }
            else
            {
                user = this.identity_context.Users.Where(x => x.Email == "user@cerberus.com").First();
            }

            this.identity_context.SaveChanges();

            //var role_manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.identity_context));
            var user_manager = new UserManager<ApplicationUser, string>(new UserStore<ApplicationUser>(this.identity_context));
            user_manager.AddToRole(super_user.Id, "SuperUser");
            user_manager.AddToRole(user.Id, "User");
        }

        public bool HasSufficientRole(string UserId, string RoleName)
        {
            var role_manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.identity_context));
            var user_manager = new UserManager<ApplicationUser, string>(new UserStore<ApplicationUser>(this.identity_context));

            var user = this.identity_context.Users.Where(x => x.Id == UserId).First();
            var role = this.identity_context.Roles.Where(x => x.Name == RoleName).First();
            bool result = user.Roles.Any(x => x.RoleId == role.Id);
            return result;
        }
    }
}