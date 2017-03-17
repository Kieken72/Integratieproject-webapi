using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;

namespace WebApi.Controllers
{
    [RoutePrefix("api/statistics")]
    [Authorize(Roles = "Manager")]
    public class StatisticsController : ApiController
    {
        private readonly IService<Branch> _branchService;
        private readonly IService<Reservation> _reservationService;
        private readonly IService<Review> _reviewService;

        public StatisticsController(IService<Branch> service, IService<Reservation> reservationService, IService<Review> reviewService )
        {
            _branchService = service;
            _reservationService = reservationService;
            _reviewService = reviewService;
        }

        [Route("reviews/{id}")]
        [HttpGet]
        public IHttpActionResult ReviewStatistics(int id)
        {
            var entity = this._reviewService.Get(e => e.BranchId == id, collections: true);

            if (entity == null) return Ok();
            var amount = entity.Count();
            var positive = entity.Count(e => e.Result);
            var negative = amount - positive;

            return Ok(new { amount, positive, negative });
        }

        [Route("weekday/{id}")]
        [HttpGet]
        public IHttpActionResult WeekdayStatistics(int id)
        {
            var entity = this._reservationService.Get(e => e.BranchId == id, collections: true);

            if (entity == null) return Ok();

            //For each weekday..
            //
            return Ok();
        }
    }
}
