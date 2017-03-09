using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests.Tests
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
                DateTime = DateTime.Now
            };
            var cResult = _controller.IsPlaceInBranches(2550, param);
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<CheckBranchDto>>;
        }

        [Test]
        public void Get_AvailableBranch()
        {
            var param = new AvailableBranchUri()
            {
                Amount = 2,
                DateTime = DateTime.Now
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
