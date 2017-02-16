using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    public class CompanyRepositoryTest
    {
        private IRepository<Company> _companies;

        private Company _company;
        private City _city;

        [SetUp]
        public void Setup()
        {
            var context = new FakeContext();

            _companies = new FakeRepository<Company>();

            _city = new City()
            {
                Id = 1,
                Name = "Antwerpen",
                PostalCode = "2000",
                Province = "Antwerpen"
            };
            _company = new Company()
            {
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                Name = "Fictief bedrijf",
                VATNumber = "Fictief Nummer"
            };
            var company2 = new Company()
            {
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                Name = "Fictief bedrijf",
                VATNumber = "Fictief Nummer"
            };
            _company = _companies.Create(_company);
            _companies.Create(company2);
        }

        [Test]
        public void ShouldCreateAndReadEntity()
        {
            Assert.AreEqual(this._companies.Read(this._company.Id), this._company);
        }

        [Test]
        public void ShouldCreateAndReadMultipleEntities()
        {
            Assert.AreEqual(2,this._companies.Read().Count());
        }

        [Test]
        public void ShouldUpdateCompany()
        {
            _company.Name = "Nieuwe fictieve naam";
            _companies.Update(_company);
            
            Assert.AreEqual(_company,_companies.Read(_company.Id));
            Assert.AreEqual(_company.Name, _companies.Read(_company.Id).Name);
        }

        [Test]
        public void ShouldThrowExceptionOnDelete()
        {
            Assert.Throws(typeof(NotSupportedException), delegate {_companies.Delete(_company.Id);});
        }

        [Test]
        public void ShouldThrowExceptionOnCreate()
        {
            var company = new Company()
            {
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id
            };
            Assert.Throws(typeof(DbEntityValidationException), delegate { _companies.Create(company); });

        }
    }
}
