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
    [RoutePrefix("api/companies")]
    public class CompanyController : ApiController
    {
        private readonly IService<Company> _service;

        public CompanyController(IService<Company> service)
        {
            _service = service;
        }

        [Route("")]
        [Authorize(Roles = "Owner")]
        //!!Authorized As Admin
        // GET: api/companies
        public IHttpActionResult Get()
        {
            var entities = this._service.Get();
            var dtos = Mapper.Map<IEnumerable<CompanyDto>>(entities);
            return Ok(dtos);
        }


        [Route("{id}")]
        [Authorize(Roles = "Owner")]
        //!!Authorized As Admin or Manager from this company
        // GET: api/companies/5
        public IHttpActionResult Get(int id)
        {
            var entity = this._service.Get(id, collections: true);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<CompanyDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        [Authorize(Roles = "SuperAdmin")]
        //!!Authorized as admin
        // POST: api/companies
        public IHttpActionResult Post([FromBody]CompanyDto value)
        {
            var entity = Mapper.Map<Company>(value);
            entity = this._service.Add(entity);
            value = Mapper.Map<CompanyDto>(entity);
            return Ok(value);

        }

        [Route("{id}")]
        [Authorize(Roles = "Owner")]
        //!!Authorized as admin or manager from this company
        // PUT: api/companies/5
        public IHttpActionResult Put(int id, [FromBody]CompanyDto value)
        {
            var entity = Mapper.Map<Company>(value);
            this._service.Change(entity);
            return Ok();
        }


        [Route("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        //!!Authorized only as admin
        // DELETE: api/companies/5
        public IHttpActionResult Delete(int id)
        {
            this._service.Remove(id);
            return Ok(); 
        }
    }
}
