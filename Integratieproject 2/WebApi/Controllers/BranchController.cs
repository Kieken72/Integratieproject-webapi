using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("api/branches")]
    public class BranchController : ApiController
    {
        private readonly IService<Branch> _service;
        private readonly IService<City> _cityService;

        public BranchController(IService<Branch> service, IService<City> cityService)
        {
            _service = service;
            _cityService = cityService;
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


            var t = _service.Get();
            var entity = this._service.Get(b=>citiesId.Contains(b.CityId)).AsEnumerable();

            //var entity = this._service.Get(b => b.CityId == city.Id, collections:true);

            var count = entity.Count();

            var dto = Mapper.Map<IEnumerable<BranchDto>>(entity);
            return Ok(dto);
        }


        // POST: api/branches
        public IHttpActionResult Post([FromBody]BranchDto value)
        {
            return Ok();
        }

        // PUT: api/branches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/branches/5
        public void Delete(int id)
        {
        }
    }
}
