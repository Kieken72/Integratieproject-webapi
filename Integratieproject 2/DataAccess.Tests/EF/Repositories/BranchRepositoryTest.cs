
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
        private Adress _adress;
        private Company _company;

        [SetUp]
        public void Setup()
        {
            var context = new FakeContext();

            _branches = new BranchRepository(context);
            _companies = new CompanyRepository(context);

            _adress = new Adress()
            {
                Street = "Groenplaats",
                Number = "1",
                PostalCode = "2000",
                City = "Antwerpen",
                Country = "België"
            };
            _company = new Company()
            {
                Adress = _adress,
                Name = "Fictief Bedrijf",
                VATNumber = "BE000X0X0"
            };
            _company=_companies.Create(_company);
            _branch = new Branch()
            {
                Name = "Fictief Filiaal",
                Email = "test@test.be",
                Adress = _adress,
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
                Adress =  _adress
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

        //[Test]
        //public void ShouldThrowExceptionOnCreate()
        //{
            
        //}







    }
}
