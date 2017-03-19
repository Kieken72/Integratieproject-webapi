using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.Business.Tests.Services
{

    //TESTEN OVERBODIG AANGEZIEN ZELFDE ALS DATAACCESS!!!
    [TestFixture]
    public class BranchServiceTests
    {
        private IService<Branch> _branches;
        private IService<Company> _companies;

        private Branch _branch;
        private City _city;
        private Company _company;
        [SetUp]
        public void SetUp()
        {
            _branches = FakeServiceFactory.Create<Branch>();
            _companies = FakeServiceFactory.Create<Company>();

            _city = new City()
            {
                Name = "Antwerpen",
                PostalCode = "2000",
                Province = "Antwerpen"
            };

            _company = new Company()
            {
                Name = "Fictief Bedrijf",
                VATNumber = "BE000X0X0",
                Street = "Groenplaats",
                Number = "1",
                City = _city
                
            };

            _company = _companies.Add(_company);

            _branch = new Branch()
            {
                Name = "Fictief Filiaal",
                Email = "test@test.be",
                Street = "Groenplaats",
                Number = "1",
                City = _city,
                CompanyId = _company.Id

            };
            _branch = _branches.Add(_branch);
        }

        [Test]
        public void ShouldCreateAndReadCompany()
        {
            Assert.AreEqual(this._branches.Get(this._branch.Id), this._branch);
        }

        [Test]
        public void ShouldUpdateCompany()
        {
            _branch.Name = "Nieuw Filaal";
            _branches.Change(_branch);
            Assert.AreEqual(this._branches.Get(this._branch.Id), this._branch);

        }

        [Test]
        public void ShouldCreateAndReadMultipleCompanies()
        {
            var branch = new Branch()
            {
                Name = "Fictief Filiaal 2",
                Email = "test@test.be",
                CompanyId = _company.Id,
            };
            _branches.Add(branch);

            Assert.AreEqual(2, this._branches.Get().Count(e => e.Id == branch.Id || e.Id == _branch.Id));
        }

    }
}
