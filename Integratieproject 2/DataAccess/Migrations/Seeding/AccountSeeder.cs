using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Leisurebooker.DataAccess.Migrations.Seeding
{
    public class AccountSeeder
    {
        public static IEnumerable<Account> Seed(Context context) {
            var manager = new UserManager<Account>(new UserStore<Account>(ContextFactory.GetContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ContextFactory.GetContext()));

            //Roles
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Owner" });
                roleManager.Create(new IdentityRole { Name = "Manager" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }


            string email;
            const string password = "MySuperP@ssword!";
            if (manager.Users.Any()) return manager.Users.AsEnumerable();
            //Acc 1
            email = "hello@leisurebooker.me";
            var user1 = new Account()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                Name = "Leisure",
                Lastname = "booker"
            };
            manager.Create(user1, password);
            user1 = manager.FindByEmail(email);
            manager.AddToRoles(user1.Id, new string[] { "SuperAdmin", "Admin", "Manager","User" });

            //Acc2

            email = "seppe.vanwinkel@student.kdg.be";
            var user2 = new Account()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                Name = "Seppe",
                Lastname = "Van Winkel"
            };
            manager.Create(user2, password);
            user2 = manager.FindByEmail(email);
            manager.AddToRoles(user2.Id, new string[] { "User" });

            //Acc3

            email = "lotte.verbraeken@student.kdg.be";
            var user3 = new Account()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                Name = "Lotte",
                Lastname = "Verbraeken"
            };
            manager.Create(user3, password);
            user3 = manager.FindByEmail(email);
            manager.AddToRoles(user3.Id, new string[] { "User" });

            //Acc4

            email = "nico.pelsmaekers@student.kdg.be";
            var user4 = new Account()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                Name = "Nico",
                Lastname = "Pelsmaekers"
            };
            manager.Create(user4, password);
            user4 = manager.FindByEmail(email);
            manager.AddToRoles(user4.Id, new string[] { "User" });

            email = "jasper.vangrieken@student.kdg.be";
            var user5 = new Account()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                Name = "Jasper",
                Lastname = "Van Grieken"
            };
            manager.Create(user5, password);
            user5 = manager.FindByEmail(email);
            manager.AddToRoles(user5.Id, new string[] { "User" });


            return manager.Users.AsEnumerable();
        }
    }
}
