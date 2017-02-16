using System;
using System.Linq;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.Tests.Fakes;
using NUnit.Framework;

namespace Leisurebooker.DataAccess.Tests.EF.Repositories
{
    [TestFixture]
    public class ReservationRepositoryTests
    {
        private IRepository<Reservation> _reservations;
        private IRepository<Space> _spaces;

        private Reservation _reservation;
        private Space _space;

        [SetUp]
        public void Setup()
        {
            //var context = new FakeContext();

            _reservations = new FakeRepository<Reservation>();
            _spaces = new FakeRepository<Space>();

            _space = new Space()
            {
                Id=1,
                MinPersons = 2,
                Persons = 8,
                Name = "Baan 8",
                Enabled = true
            };
            _space = _spaces.Create(_space);

            var now = DateTime.Now;
            _reservation = new Reservation()
            {
                Id = 1,
                AmountOfPersons = 2,
                SpaceId = _space.Id,
                DateTime = new DateTime(now.Year,now.Month,now.Day,15,00,00),
                EndDateTime = new DateTime(now.Year, now.Month, now.Day, 17, 00, 00)
            };
            var reservation2 = new Reservation()
            {
                Id = 2,
                AmountOfPersons = 2,
                SpaceId = _space.Id,
                DateTime = new DateTime(now.Year, now.Month, now.Day, 17, 00, 00),
                EndDateTime = new DateTime(now.Year, now.Month, now.Day, 19, 00, 00)
            };

            _reservations.Create(_reservation);
            _reservations.Create(reservation2);
        }

        [Test]
        public void ShouldCreateAndReadEntity()
        {
            Assert.AreEqual(_reservation, _reservations.Read(_reservation.Id));
        }

        [Test]
        public void ShouldReadMultipleEntities()
        {
            Assert.AreEqual(2, this._reservations.Read().Count());
        }

        [Test]
        public void ShouldUpdateBranch()
        {
            _reservation.AmountOfPersons = 4;
            _reservations.Update(_reservation);

            Assert.AreEqual(_reservation, _reservations.Read(_reservation.Id));
            Assert.AreEqual(_reservation.AmountOfPersons, _reservations.Read(_reservation.Id).AmountOfPersons);
        }

        [Test]
        public void ShouldDeleteEntity()
        {
            _reservations.Delete(_reservation.Id);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _reservations.Read(_reservation.Id); });
        }







    }
}
