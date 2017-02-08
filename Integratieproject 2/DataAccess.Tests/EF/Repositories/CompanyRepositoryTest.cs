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

            _companies = new CompanyRepository(context);

            _city = new CityRepository().Read().First();
            _company = new Company()
            {
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                Name = "Fictief bedrijf",
                VATNumber = "Fictief Nummer"
            };
            _company = _companies.Create(_company);
        }

        [Test]
        public void ShouldCreateAndReadEntity()
        {
            Assert.AreEqual(this._companies.Read(this._company.Id), this._company);
        }

        [Test]
        public void ShouldCreateAndReadMultipleEntities()
        {
            var company = new Company()
            {
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                Name = "Fictief bedrijf",
                VATNumber = "Fictief Nummer"
            };
            company = _companies.Create(company);

            Assert.AreEqual(2,this._companies.Read().Count(e => e.Id==company.Id||e.Id==_company.Id));
        }

        [Test]
        public void ShouldUpdateCompany()
        {
            _company.Name = "Nieuwe fictieve naam";
            _companies.Update(_company);
            
            Assert.AreEqual(_company,_companies.Read(_company.Id));
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
