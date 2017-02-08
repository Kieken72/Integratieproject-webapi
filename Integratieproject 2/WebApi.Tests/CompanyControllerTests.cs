using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests
{
    [TestFixture]
    public class CompanyControllerTests
    {
        private CompanyController _controller;
        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<CityProfile>();
            });
            _controller = new CompanyController(new CompanyService());


        }

        [Test]
        public void Get_ReturnsMultipleCompanies()
        {
            var cResult = _controller.Get();
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<CompanyDto>>;
            Assert.IsNotEmpty(rResult.Content);
        }

        [Test]
        public void Get_CorrectIdWillGetEntityAndOkResult()
        {
            var cResult = _controller.Get(1);
            var rResult = cResult as OkNegotiatedContentResult<CompanyDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<CompanyDto>>(cResult);
        }

        [Test]
        public void Post_AddsNewEntityToDatabaseAndOkResult()
        {
            var dto = new CompanyDto()
            {
                Name = "Bedrijf",
                VATNumber = "BE0123456789",
                CityId = 1,
                Street = "Straat",
                Number = "nummer"
            };
            var cResult = _controller.Post(dto);
            var rResult = cResult as OkNegotiatedContentResult<CompanyDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<CompanyDto>>(cResult);
        }

    }
}
