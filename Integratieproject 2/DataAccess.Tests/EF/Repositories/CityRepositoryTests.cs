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
        [SetUp]
        public void SetUp()
        {
            //var context = new FakeContext();

            _cities = new FakeRepository<City>();

            _cities.Create(new City()
            {
                Id=1,
                Name = "Antwerpen",
                Province = "Antwerpen",
                PostalCode = "2000"
            });
            _cities.Create(new City()
            {
                Id = 2,
                Name = "Duffel",
                Province = "Antwerpen",
                PostalCode = "2570"
            });
            _cities.Create(new City()
            {
                Id = 3,
                Name = "Kontich",
                Province = "Antwerpen",
                PostalCode = "2550"
            });
        }

        [Test]
        public void ShouldSearchByPostalAndReturnCity()
        {
            Assert.AreEqual("2000",_cities.Read().FirstOrDefault(e=>e.PostalCode=="2000").PostalCode);
        }

        [Test]
        public void ShouldSearchById()
        {
            Assert.AreEqual(1, _cities.Read(1).Id);
        }
        [Test]
        public void ShouldReadMultipleEntities()
        {
            Assert.AreEqual(3, _cities.Read().Count());
        }
    }
}
