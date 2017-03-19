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
    public class ReviewControllerTests
    {
        private ReviewController _controller;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ReviewProfile>();
                cfg.AddProfile<ReservationProfile>();
                cfg.AddProfile<AccountProfile>();
            });
            _controller = new ReviewController(new ReviewService(), new ReservationService());
        }

        [Test]
        public void Get_ReviewsByBranchId()
        {
            var cResult = _controller.ByBranch(1);
            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<ReviewDto>>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<IEnumerable<ReviewDto>>>(cResult);
        }
    }
}
