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

        [Route("guests/{id}")]
        [HttpGet]
        public IHttpActionResult AmountGuestsStatistics(int id)
        {
            var entity = this._reservationService.Get(e => e.BranchId == id, collections: true);

            if (entity == null) return Ok();

            var one = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 1,collections:true).Count();
            var two = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 2, collections: true).Count();
            var three = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 3, collections: true).Count();
            var four = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 4, collections: true).Count();
            var five = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 5, collections: true).Count();
            var six = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 6, collections: true).Count();
            var seven = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 7, collections: true).Count();
            var eight = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 8, collections: true).Count();
            var nine = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 9, collections: true).Count();
            var ten = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons == 10, collections: true).Count();
            var more = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.AmountOfPersons > 10, collections: true).Count();

            //For each weekday..
            //
            return Ok(new
            {
                one,
                two,
                three,
                four,
                five,
                six,
                seven,
                eight,
                nine,
                ten,
                more
            });
        }

        [Route("weekday/{id}")]
        [HttpGet]
        public IHttpActionResult WeekdayStatistics(int id)
        {
            var entity = this._reservationService.Get(e => e.BranchId == id, collections: true);

            if (entity == null) return Ok();

            var monday = this._reservationService.Get(e => e.BranchId == id, e => !e.Cancelled,
                e => e.DateTime.DayOfWeek == DayOfWeek.Monday, collections: true).Count();
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
