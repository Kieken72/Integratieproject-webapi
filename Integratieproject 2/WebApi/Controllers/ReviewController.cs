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

        //[Route("")]
        //// GET: api/reviews
        //public IHttpActionResult Get()
        //{
        //    var entities = this._service.Get();
        //    var dtos = Mapper.Map<IEnumerable<ReviewDto>>(entities);
        //    return Ok(dtos);
        //}

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
        // GET: api/reviews/5
        public IHttpActionResult ByBranch(int id)
        {
            var entity = this._service.Get(e=>e.BranchId==id, collections: true);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<ReviewDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        [Authorize]
        // POST: api/branches
        public IHttpActionResult Post([FromBody]ReviewDto value)
        {
            value.UserId = User.Identity.GetUserId();
            //var user = User.Identity.GetUserId();
            //var reservation = _reservationService.Get(e => e.AccountId == user);
            //To Check if reservation was made by this user..
            var entity = Mapper.Map<Review>(value);
            entity = this._service.Add(entity);
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
        //!!Authorized only as admin
        // DELETE: api/reviews/5
        public IHttpActionResult Delete(int id)
        {

            this._service.Remove(id);
            return Ok();
        }
    }
}
