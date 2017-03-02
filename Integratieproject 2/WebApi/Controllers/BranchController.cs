using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using WebApi.Models.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("api/branches")]
    public class BranchController : ApiController
    {
        private readonly IService<Branch> _service;
        private readonly IService<City> _cityService;
        private readonly IService<Space> _spaceService;
        private readonly IService<Room> _roomService;

        public BranchController(IService<Branch> service, IService<City> cityService, IService<Space> spaceService, IService<Room> roomService  )
        {
            _service = service;
            _cityService = cityService;
            _spaceService = spaceService;
            _roomService = roomService;
        }

        [Route("")]
        // GET: api/branches
        public IHttpActionResult Get()
        {
            var entities = this._service.Get();
            var dtos = Mapper.Map<IEnumerable<BranchDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        // GET: api/branches/5
        public IHttpActionResult Get(int id)
        {
            var entity = this._service.Get(id, collections: true);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<BranchDto>(entity);
            return Ok(dto);
        }

        [Route("by-postal/{postalcode}")]
        public IHttpActionResult GetByPostalCode(int postalcode)
        {
            var postalString = postalcode.ToString();

            var cities = _cityService.Get(e => e.PostalCode == postalString).ToList();
            if (!cities.Any())
            {
                return NotFound();
            }
            var citiesId = cities.Select(city => city.Id).ToList();

            var entities = this._service.Get(b=>citiesId.Contains(b.CityId)).AsEnumerable();

            var dto = Mapper.Map<IEnumerable<BranchDto>>(entities);
            return Ok(dto);
        }

        


        [Route("")]
        //!!Authorized as manager from company
        // POST: api/branches
        public IHttpActionResult Post([FromBody]BranchDto value)
        {
            var entity = Mapper.Map<Branch>(value);
            entity = this._service.Add(entity);
            value = Mapper.Map<BranchDto>(entity);
            return Ok(value);

        }

        [Route("new-room")]
        [HttpPost]
        public IHttpActionResult NewRoom([FromBody] RoomDto value)
        {
            var entity = Mapper.Map<Room>(value);
            entity = this._roomService.Add(entity);
            value = Mapper.Map<RoomDto>(entity);
            return Ok(value);
        }

        [Route("{id}")]
        //!!Authorized as manager from this company
        // PUT: api/branches/5
        public IHttpActionResult Put(int id, [FromBody]BranchDto value)
        {
            var entity = Mapper.Map<Branch>(value);
            this._service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        //!!Authorized only as admin
        // DELETE: api/branches/5
        public IHttpActionResult Delete(int id)
        {
            this._service.Remove(id);
            return Ok();
        }
    }
}
