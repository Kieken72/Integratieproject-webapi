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
            var context = new FakeContext();

            _cities = new CityRepository(context);
        }

        [Test]
        public void ShouldSearchReadCity()
        {
            Assert.AreEqual("2000",_cities.Read().FirstOrDefault(e=>e.PostalCode=="2000"));
        }
    }
}
