using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests
{
    [TestFixture()]
    public class CityControllerTests
    {
        private CityController _controller;
        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CityProfile>();
            });
            _controller = new CityController(new CityService());
        }
        [Test]
        public void Get_ReturnsMultipleCities()
        {

            var cResult = _controller.Get();
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<CityDto>>;
            Assert.IsNotEmpty(rResult.Content);
        }

        [Test]
        public void GetByPostalCode_CorrectPostalCodeWillGetCityEntityAndOkResult()
        {
            var cResult = _controller.GetByPostalCode(2000);
            var rResult = cResult as OkNegotiatedContentResult<FullCityDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<FullCityDto>>(cResult);
            Assert.AreEqual("2000",rResult.Content.PostalCode);
        }

        [Test]
        public void GetByPostalCode_WrongPostalCodeWillGetNotFoundResult()
        {
            var cResult = _controller.GetByPostalCode(0);
            var rResult = cResult as NotFoundResult;
            Assert.IsInstanceOf<NotFoundResult>(rResult);

        }
        [Test]
        public void Get_CorrectIdWillGetCityEntityAndOkResult()
        {
            var cResult = _controller.Get(1);
            var rResult = cResult as OkNegotiatedContentResult<FullCityDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<FullCityDto>>(cResult);
            Assert.AreEqual("1000", rResult.Content.PostalCode);
        }

        [Test]
        public void Get_WrongIdWillGetNotFoundResult()
        {
            var cResult = _controller.Get(0);
            var rResult = cResult as NotFoundResult;
            Assert.IsInstanceOf<NotFoundResult>(rResult);

        }

        [Test]
        public void Post_BadRequest()
        {
            var cResult = _controller.Post(null);
            Assert.IsInstanceOf<BadRequestResult>(cResult);
        }
        [Test]
        public void Put_BadRequest()
        {
            var cResult = _controller.Put(null);
            Assert.IsInstanceOf<BadRequestResult>(cResult);
        }
        [Test]
        public void Delete_BadRequest()
        {
            var cResult = _controller.Delete(0);
            Assert.IsInstanceOf<BadRequestResult>(cResult);
        }

    }
}
