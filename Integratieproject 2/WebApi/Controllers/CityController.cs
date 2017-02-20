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

        // GET: api/cities
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
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<FullCityDto>(entity);
            return Ok(dto);
        }

        [Route("by-postal/{postalcode}")]
        // GET: api/cities/bt-postal/2000
        public IHttpActionResult GetByPostalCode(int postalcode)
        {
            var postalString = postalcode.ToString();
            var entity = this._service.Get(e=>e.PostalCode == postalString).AsEnumerable();
            if (!entity.Any())
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<FullCityDto>>(entity);
            return Ok(dto);
        }
        //TEST VOOR AUTOCOMPLETE
        //[Route("contains/{postalcodeString}")]
        //public IHttpActionResult GetByContainsPostalCode(string postalcodeString)
        //{
        //    var entity = this._service.Get(e => e.PostalCode.Contains(postalcodeString)).AsEnumerable();
        //    if (!entity.Any())
        //    {
        //        return NotFound();
        //    }
        //    var dto = Mapper.Map<IEnumerable<FullCityDto>>(entity);
        //    return Ok(dto);
        //}

        [Route("")]
        // POST: api/cities
        public IHttpActionResult Post([FromBody] FullCityDto dto)
        {
            return BadRequest();
        }

        [Route("")]
        // PUT: api/cities
        public IHttpActionResult Put([FromBody]FullCityDto dto)
        {
            return BadRequest();
        }

        [Route("{id}")]
        // DELETE: api/cities
        public IHttpActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
