using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.Business.Tests.Services
{
    [TestFixture]
    [Author("Seppe")]
    public class CompanyServiceTests
    {
        private IService<Company> _service;
        private Company _company;
        [SetUp]
        public void SetUp()
        {
            _service = FakeServiceFactory.Create<Company>();

            _company = new Company()
            {
                Name = "Bowling Bvba",
                VATNumber = "0123456789",
                Adress = new Address()
                {
                    Street = "Groenplaats",
                    Number = "1",
                    PostalCode = "2000",
                    City = "Antwerpen",
                    Country = "België"
                }
            };
            _service.Add(_company);
        }

        [Test]
        public void ShouldCreateAndReadCompany()
        {
            Assert.AreEqual(this._service.Get(this._company.Id), this._company);
        }

        [Test]
        public void ShouldUpdateCompany()
        {
            _company.VATNumber = "0987654321";
            _service.Change(_company);
            Assert.AreEqual(this._service.Get(this._company.Id), this._company);

        }

        [Test]
        public void ShouldCreateAndReadMultipleCompanies()
        {
            var company = new Company()
            {
                Name = "Bowling VZW",
                VATNumber = "0123456789",
                Adress = new Address()
                {
                    Street = "Groenplaats",
                    Number = "1",
                    PostalCode = "2000",
                    City = "Antwerpen",
                    Country = "België"
                }
            };
            _service.Add(company);

            Assert.AreEqual(2, this._service.Get().Count(e => e.Id == company.Id || e.Id == _company.Id));
        }

    }
}
