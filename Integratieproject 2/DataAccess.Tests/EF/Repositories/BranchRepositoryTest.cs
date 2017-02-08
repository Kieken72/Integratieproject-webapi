
using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;
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
            var context = new FakeContext();

            _branches = new BranchRepository(context);
            _companies = new CompanyRepository(context);
            var cities = new CityRepository(context);

            _city = cities.Read().First();
            
            _company = new Company()
            {
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                Name = "Fictief Bedrijf",
                VATNumber = "BE000X0X0"
            };
            _company=_companies.Create(_company);
            _branch = new Branch()
            {
                Name = "Fictief Filiaal",
                Email = "test@test.be",
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id,
                CompanyId = _company.Id

            };
            _branch = _branches.Create(_branch);
        }

        [Test]
        public void ShouldCreateAndReadEntity()
        {
            Assert.AreEqual(_branch, _branches.Read(_branch.Id));
        }

        [Test]
        public void ShouldCreateAndReadMultipleEntities()
        {
            var branch = new Branch()
            {
                Name = "Fictief Filiaal 2",
                Email = "test@test.be",
                CompanyId = _company.Id,
                Street = "Groenplaats",
                Number = "1",
                CityId = _city.Id
            };
            branch =  _branches.Create(branch);
            Assert.AreEqual(2, this._branches.Read().Count(e => e.Id == _branch.Id || e.Id == branch.Id));
        }

        [Test]
        public void ShouldUpdateBranch()
        {
            _branch.Email = "test@test.be";
            _branch.PhoneNumber = "009181856";
            _branches.Update(_branch);

            Assert.AreEqual(_branch, _branches.Read(_branch.Id));
        }







    }
}
