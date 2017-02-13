using System.Collections.Generic;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Leisurebooker.DataAccess.EF.Connection.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Leisurebooker.DataAccess.EF.Connection.Context context)
        {
            var manager = new UserManager<Account>(new UserStore<Account>(ContextFactory.GetContext()));

            var user = new Account()
            {
                UserName = "hello@leisurebooker.me",
                Email = "hello@leisurebooker.me",
                EmailConfirmed = true,
                Name = "Leisure",
                Surname = "booker"
            };

            manager.Create(user, "MySuperP@ssword!");

            CitiesSeeder.Seed(context);

            context.Companies.AddRange(new List<Company>()
            {
                new Company()
                {
                    Name = "Involved",
                    VATNumber = "BE0544984305",
                    CityId =343,
                    Street = "Veldkant",
                    Number = "33a",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            Name = "HeadQ",
                            Street = "Veldkant",
                            Number = "33a",
                            CityId = 343,
                            OpeningHours = new List<OperationHours>()
                            {
                                new OperationHours(DayOfWeek.Monday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Tuesday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Wednesday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Thursday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Friday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Sunday, 11,30,17,30)
                            },
                            Email = "post@involved-it.be"
                        }
                    }
                }
            });
            


        }
    }
}
