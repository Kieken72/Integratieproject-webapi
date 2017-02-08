using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;
using Leisurebooker.DataAccess.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.DataAccess.Tests.EF.Repositories
{

    [TestFixture]
    public class CityRepositoryTests
    {
        private IRepository<City> _cities;
        private City _city;
        [SetUp]
        public void SetUp()
        {
            var context = new FakeContext();

            _cities = new CityRepository(context);

            _city = new City()
            {
                PostalCode = "0000",
                Name = "Test",
                Province = "Test"
            };
           _city = _cities.Create(_city);
        }

        [Test]
        public void ShouldCreateAndReadCity()
        {
            Assert.AreEqual(_city,_cities.Read(_city.Id));
        }
    }
}
