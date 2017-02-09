using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.Business.Tests.Services
{
    [TestFixture]
    public class BranchServiceTests
    {
        private IService<Branch> _branches;
        private IService<Company> _companies;

        private Branch _branch;
        //private Address _adress;
        private Company _company;
        [SetUp]
        public void SetUp()
        {
            _branches = FakeServiceFactory.Create<Branch>();
            _companies = FakeServiceFactory.Create<Company>();

            //_adress = new Address()
            //{
            //    Street = "Groenplaats",
            //    Number = "1",
            //    PostalCode = "2000",
            //    City = "Antwerpen",
            //    Country = "België"
            //};
            _company = new Company()
            {
                //Adress = _adress,
                Name = "Fictief Bedrijf",
                VATNumber = "BE000X0X0"
            };
            _company = _companies.Add(_company);
            _branch = new Branch()
            {
                Name = "Fictief Filiaal",
                Email = "test@test.be",
                //Adress = _adress,
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
                //Adress = _adress
            };
            _branches.Add(branch);

            Assert.AreEqual(2, this._branches.Get().Count(e => e.Id == branch.Id || e.Id == _branch.Id));
        }

    }
}
