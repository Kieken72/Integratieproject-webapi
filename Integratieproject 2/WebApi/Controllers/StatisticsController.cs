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

            var monday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Monday,collections:true).Count();
            var tuesday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Tuesday, collections: true).Count();
            var wednesday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Wednesday, collections: true).Count();
            var thursday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Thursday, collections: true).Count();
            var friday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Friday, collections: true).Count();
            var saturday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Saturday, collections: true).Count();
            var sunday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Sunday, collections: true).Count();

            //For each weekday..
            //
            return Ok(new
            {
                monday,
                tuesday,
                wednesday,
                thursday,
                friday,
                saturday,
                sunday
            });
        }
    }
}
