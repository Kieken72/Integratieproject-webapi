﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Tests.Fakes;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests.Tests
{
    [TestFixture]
    public class CompanyControllerTests
    {
        private CompanyController _controller;
        private ICollection<Company> _companies;
        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<CityProfile>();
            });
            
            var fakeService = new FakeService<Company>();
            _companies = new List<Company>();
            for (int j = 1; j <= 5; j++)
            {
                var company = new Company()
                {
                    Name = $"Company {j}",
                    Street = "Streetname",
                    Number = $"{j}",
                    City = new City()
                    {
                        PostalCode = "2000",
                        Name = "Antwerpen",
                        Province = "Antwerpen"
                    },
                    VATNumber = $"BE012345678{j}"
                
                };
                fakeService.Add(company);
                _companies.Add(company);
            }
            //Setup Test objects

            _controller = new CompanyController(fakeService);



        }

        [Test]
        public void Get_ReturnsMultipleCompanies()
        {
            var cResult = _controller.Get();
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<CompanyDto>>;
            Assert.IsNotEmpty(rResult.Content);
            Assert.AreEqual(_companies.Count,rResult.Content.Count());
        }

        [Test]
        public void Get_CorrectIdWillGetEntityAndOkResult()
        {
            var cResult = _controller.Get(1);
            var rResult = cResult as OkNegotiatedContentResult<CompanyDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<CompanyDto>>(cResult);
            Assert.AreEqual(_companies.FirstOrDefault(e => e.Id==1).Id,rResult.Content.Id);
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

        [Test]
        public void Put_EditEntityToDatabaseAndOkResult()
        {
            var dto = new CompanyDto()
            {
                Name = "Bedrijf",
                VATNumber = "BE0123456789",
                CityId = 1,
                Street = "Straat",
                Number = "nummer"
            };
            //put?
            var cResult = _controller.Post(dto);
            var rResult = cResult as OkNegotiatedContentResult<CompanyDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<CompanyDto>>(cResult);
        }

    }
}
