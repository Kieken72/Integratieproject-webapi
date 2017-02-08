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
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private readonly IService<Company> _service;

        public CompanyController(IService<Company> service)
        {
            _service = service;
        }

        [Route("")]
        // GET: api/Company
        public IEnumerable<CompanyDto> Get()
        {

            return Mapper.Map<IEnumerable<CompanyDto>>(_service.Get());
        }


        [Route("{id}")]
        // GET: api/Company/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("")]
        // POST: api/Company
        public void Post([FromBody]Company value)
        {
            _service.Add(value);
        }

        [Route("{id}")]
        // PUT: api/Company/5
        public void Put(int id, [FromBody]string value)
        {
        }


        [Route("{id}")]
        // DELETE: api/Company/5
        public void Delete(int id)
        {

        }
    }
}
