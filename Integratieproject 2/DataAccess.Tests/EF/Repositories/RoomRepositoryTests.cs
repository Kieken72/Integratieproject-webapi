using System;
using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.DataAccess.Tests.EF.Repositories
{
    [TestFixture]
    public class RoomRepositoryTests
    {
        private IRepository<Room> _rooms;

        private Room _room;

        [SetUp]
        public void Setup()
        {
            //var context = new FakeContext();

            _rooms = new FakeRepository<Room>();

            _room = new Room()
            {
                Id=1,
                BranchId = 1,
                Enabled = true,
                Height = 10,
                Width = 10,
                Name = "Zaal 1"
            };
            var room2 = new Room()
            {
                Id = 2,
                BranchId = 1,
                Enabled = true,
                Height = 10,
                Width = 10,
                Name = "Zaal 2"
            };

            _rooms.Create(_room);
            _rooms.Create(room2);
        }


        [Test]
        public void ShouldCreateAndReadEntity()
        {
            Assert.AreEqual(_room, _rooms.Read(_room.Id));
        }

        [Test]
        public void ShouldReadMultipleEntities()
        {
            Assert.AreEqual(2, this._rooms.Read().Count());
        }

        [Test]
        public void ShouldUpdateBranch()
        {
            _room.Name = "Zaal Nieuw";
            _rooms.Update(_room);

            Assert.AreEqual(_room, _rooms.Read(_room.Id));
            Assert.AreEqual(_room.Name, _rooms.Read(_room.Id).Name);
        }

        [Test]
        public void ShouldDeleteEntity()
        {
            _rooms.Delete(_room.Id);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _rooms.Read(_room.Id); });
        }







    }
}
