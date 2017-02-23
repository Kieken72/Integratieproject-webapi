using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WebApi.Controllers;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests
{
    [TestFixture()]
    public class ReservationControllerTests
    {
        private ReservationController _controller;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ReservationProfile>();
                cfg.AddProfile<BranchProfile>();
                cfg.AddProfile<CityProfile>();
            });
            _controller = new ReservationController(new BranchService(), new CityService(), new SpaceService(),
                new ReservationService());

        }

        [Test]
        public void Get_AvailableBranches()
        {
            var param = new AvailableBranchUri()
            {
                Amount = 2,
                Hours = 16,
                Day = 8,
                Minutes = 30,
                Month = 2,
                Year = 2016
            };
            var cResult = _controller.IsPlaceInBranches(2550,param);
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<CheckBranchDto>>;
        }

        [Test]
        public void Get_AvailableBranch()
        {
            var param = new AvailableBranchUri()
            {
                Amount = 2,
                Hours = 16,
                Day = 8,
                Minutes = 30,
                Month = 2,
                Year = 2016
            };
            var cResult = _controller.IsPlaceInBranches(1, param);
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<CheckBranchDto>;
        }

        [Test]
        public void Post_MakeNewReservation()
        {
            var reservation = new NewReservationDto()
            {
                BranchId = 1,
                Amount = 10,
                DateTime = DateTime.Now
            };
            var cResult = _controller.ReserveSpace(reservation);
            Assert.NotNull(cResult);
        }

    }
}
