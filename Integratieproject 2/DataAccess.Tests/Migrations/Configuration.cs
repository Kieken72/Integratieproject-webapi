using System.Collections.Generic;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.Tests.Fakes;
using System.Data.Entity.Migrations;

namespace Leisurebooker.DataAccess.Tests.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<FakeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FakeContext context)
        {
            context.Cities.AddRange(new List<City>()
            {
                new City()
                {
                    Name = "Boechout",
                    PostalCode = "2530",
                    Province = "Antwerpen",
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
            context.Companies.Add(new Company()
            {
                Name = "Company 1",
                VATNumber = "BE0123456789",
                CityId = 1,
                Street = "Straat",
                Number = "1"
                
            });
            context.SaveChanges();
        }
    }
}
