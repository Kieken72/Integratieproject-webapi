using System.Collections.Generic;
using Leisurebooker.Business.Domain;

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
            context.Cities.AddRange(new List<City>()
            {
                new City()
                {
                    Name = "Boechout",
                    PostalCode = "2530",
                    Province = "Antwerpen"
                },
                new City()
                {
                    Name = "Mechelen",
                    PostalCode = "2800",
                    Province = "Antwerpen"
                },
                new City()
                {
                    Name = "Zoersel",
                    PostalCode = "2980",
                    Province = "Antwerpen"
                },
                new City()
                {
                    Name = "Melsele",
                    PostalCode = "9120",
                    Province = "Oost-Vlaanderen"
                }

            });
        }
    }
}
