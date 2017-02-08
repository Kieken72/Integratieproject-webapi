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
    [RoutePrefix("api/cities")]
    public class CityController : ApiController
    {
        private readonly IService<City> _service;

        public CityController(IService<City> service)
        {
            _service = service;
        }

        // GET: api/City
        [Route("")]
        public IHttpActionResult Get()
        {
            var entities = this._service.Get();
            var dtos =  Mapper.Map<IEnumerable<CityDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        // GET: api/City/5
        public IHttpActionResult Get(int id)
        {
            var entity = this._service.Get(id, collections: true);
            var dto = Mapper.Map<FullCityDto>(entity);
            return Ok(dto);
        }

        // POST: api/City
        public IHttpActionResult Post([FromBody]string value)
        {
            return BadRequest();
        }

        // PUT: api/City/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return BadRequest();
        }

        // DELETE: api/City/5
        public IHttpActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
