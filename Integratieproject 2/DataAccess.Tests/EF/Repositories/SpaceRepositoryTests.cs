using System;
using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.DataAccess.Tests.EF.Repositories
{
    [TestFixture]
    public class SpaceRepositoryTests
    {
        private IRepository<Space> _spaces;

        private Space _space;

        [SetUp]
        public void Setup()
        {
            //var context = new FakeContext();

            _spaces = new FakeRepository<Space>();

            _space = new Space()
            {
                Id=1,
                RoomId = 1,
                Enabled = true,
                Name = "Baan 1",
                MinPersons = 2,
                Persons = 8
            };
            var space2 = new Space()
            {
                Id = 2,
                RoomId = 1,
                Enabled = true,
                Name = "Baan 2",
                MinPersons = 8,
                Persons = 10
            };

            _spaces.Create(_space);
            _spaces.Create(space2);
        }


        [Test]
        public void ShouldCreateAndReadEntity()
        {
            Assert.AreEqual(_space, _spaces.Read(_space.Id));
        }

        [Test]
        public void ShouldReadMultipleEntities()
        {
            Assert.AreEqual(2, this._spaces.Read().Count());
        }

        [Test]
        public void ShouldUpdateBranch()
        {
            _space.Name = "Nieuwe Baan";
            _spaces.Update(_space);

            Assert.AreEqual(_space, _spaces.Read(_space.Id));
            Assert.AreEqual(_space.Name, _spaces.Read(_space.Id).Name);
        }

        [Test]
        public void ShouldDeleteEntity()
        {
            _spaces.Delete(2);
            _spaces.Delete(_space.Id);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _spaces.Read(_space.Id); });
        }







    }
}
