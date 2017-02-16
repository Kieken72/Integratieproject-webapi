using System;
using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.DataAccess.Tests.EF.Repositories
{
    [TestFixture]
    public class BranchRepositoryTest
    {
        private IRepository<Branch> _branches;
        private IRepository<Company> _companies;

        private Branch _branch;
        private Company _company;
        private City _city;

        [SetUp]
        public void Setup()
        {
            //var context = new FakeContext();

            _branches = new FakeRepository<Branch>();
            _companies = new FakeRepository<Company>();
            //var cities = new FakeRepository<City>();

            
            _city = new City()
            {
                Id=1,
                Name = "Antwerpen",
                PostalCode = "2000",
                Province = "Antwerpen"
            };
            
            _company = new Company()
            {
                Id = 1,
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                Name = "Fictief Bedrijf",
                VATNumber = "BE000X0X0"
            };
            _company=_companies.Create(_company);
            _branch = new Branch()
            {
                Id = 1,
                Name = "Fictief Filiaal",
                Email = "test@test.be",
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                CompanyId = _company.Id

            };
            var branch2 = _branch = new Branch()
            {
                Id = 2,
                Name = "Fictief Filiaal 2",
                Email = "test2@test.be",
                Street = "Groenplaats",
                Number = "3",
                CityId = _city.Id,
                CompanyId = _company.Id

            };
            _branch = _branches.Create(_branch);
            _branches.Create(branch2);
        }

        [Test]
        public void ShouldCreateAndReadEntity()
        {
            Assert.AreEqual(_branch, _branches.Read(_branch.Id));
        }

        [Test]
        public void ShouldReadMultipleEntities()
        {
            Assert.AreEqual(2, this._branches.Read().Count());
        }

        [Test]
        public void ShouldUpdateBranch()
        {
            _branch.Email = "newTest@test.be";
            _branch.PhoneNumber = "009181856";
            _branches.Update(_branch);

            Assert.AreEqual(_branch, _branches.Read(_branch.Id));
            Assert.AreEqual(_branch.Email, _branches.Read(_branch.Id).Email);
        }

        [Test]
        public void ShouldDeleteEntity()
        {
            _branches.Delete(_branch.Id);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _branches.Read(_branch.Id); });
        }







    }
}
