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
    public class CompanyRepositoryTest
    {
        private IRepository<Company> _companies;

        private Company _company;

        [SetUp]
        public void Setup()
        {
            var context = new FakeContext();

            _companies = new CompanyRepository(context);

            _company = new Company()
            {
                Adress = new Adress()
                {
                    Street = "Fictieve straat",
                    Number = "1",
                    City = "Antwerpen",
                    PostalCode = "2000",
                    Box = ""
                },
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
    }
}
