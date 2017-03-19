using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using Microsoft.AspNet.Identity;
using WebApi.Models.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("api/reviews")]

    public class ReviewController : ApiController
    {
        private readonly IService<Review> _service;
        private readonly IService<Reservation> _reservationService;

        public ReviewController(IService<Review> service, IService<Reservation> reservationService )
        {
            _service = service;
            _reservationService = reservationService;
        }

        [Route("{id}")]
        // GET: api/reviews/5
        public IHttpActionResult Get(int id)
        {
            var entity = this._service.Get(id, collections: true);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<ReviewDto>(entity);
            return Ok(dto);
        }

        [Route("by-branch/{id}")]
        [Authorize(Roles = "Manager")]
        [HttpGet]
        // GET: api/reviews/5
        public IHttpActionResult ByBranch(int id)
        {
            var entity = this._service.Get(e=>e.BranchId==id, collections: true);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<ReviewDto>>(entity);
            return Ok(dto);
        }

        [Route("")]
        [Authorize]
        // POST: api/branches
        public IHttpActionResult Post([FromBody]ReviewDto value)
        {
            value.UserId = User.Identity.GetUserId();
            var reservation = _reservationService.Get(value.ReservationId);
            if (reservation == null)
            {
                return NotFound();
            }
            if (reservation.Review != null)
            {
                return Conflict();
            }
            value.BranchId = reservation.BranchId;
            var entity = Mapper.Map<Review>(value);
            reservation.Review = entity;
            this._reservationService.Change(reservation);
            //entity = this._service.Add(entity);
            value = Mapper.Map<ReviewDto>(entity);
            return Ok(value);

        }

        //[Route("{id}")]
        ////!!Authorized as manager from this company
        //// PUT: api/reviews/5
        //public IHttpActionResult Put(int id, [FromBody]ReviewDto value)
        //{
        //    var entity = Mapper.Map<Review>(value);
        //    this._service.Change(entity);
        //    return Ok();
        //}

        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        //!!Authorized only as admin
        // DELETE: api/reviews/5
        public IHttpActionResult Delete(int id)
        {

            this._service.Remove(id);
            return Ok();
        }
    }
}
