using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Mapping;

namespace WebApi.Tests
{
    [TestFixture]
    public class CompanyControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<AddressProfile>();
            });
        }
        [Test]
        public void TestController()
        {
            var controller = new CompanyController(new CompanyService());

            var results = controller.Get();

            Assert.IsNotNull(results);
            Assert.IsNotEmpty(results);
        }
    }
}
