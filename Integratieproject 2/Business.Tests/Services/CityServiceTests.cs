using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.Business.Tests.Services
{
    [TestFixture]
    public class CityServiceTests
    {

        private IService<City> _cities;

        [SetUp]
        public void SetUp()
        {
            _cities = new FakeService<City>();
            _cities.Add(new City()
            {
                Name = "Antwerpen",
                PostalCode = "2000",
                Province = "Antwerpen"
            });
           
        }

        [Test]
        public void ReadAndFindCity()
        {
            Assert.AreEqual("2000",_cities.Get(e=>e.PostalCode=="2000").FirstOrDefault().PostalCode);
        }
    }
}
