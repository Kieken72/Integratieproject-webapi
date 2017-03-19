using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Dto;

namespace WebApi.Tests.Tests
{
    [TestFixture]
    public class StatisticsControllerTests
    {
        private StatisticsController _controller;

        [SetUp]
        public void SetUp()
        {
         
            _controller = new StatisticsController(new BranchService(), new ReservationService(), new ReviewService());   
        }

        [Test]
        public void Get_ReviewStatistics()
        {
            const int branchId = 1;
            var cResult = _controller.ReviewStatistics(branchId);
            Assert.IsNotNull(cResult);

            //Testen van anonymous types werkt niet.
        }

        [Test]
        public void Get_GuestStatistics()
        {
            const int branchId = 1;
            var cResult = _controller.AmountGuestsStatistics(branchId);
            Assert.IsNotNull(cResult);

            //Testen van anonymous types werkt niet.
        }
        [Test]
        public void Get_WeekdayStatistics()
        {
            const int branchId = 1;
            var cResult = _controller.WeekdayStatistics(branchId);
            Assert.IsNotNull(cResult);

            //Testen van anonymous types werkt niet.
        }


    }
}
