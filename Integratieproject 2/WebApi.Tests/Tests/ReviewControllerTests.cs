using AutoMapper;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
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
            });
            _controller = new ReviewController(new ReviewService(), new ReservationService());
        }
    }
}
