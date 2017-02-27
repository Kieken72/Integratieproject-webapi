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
    [RoutePrefix("api/messages")]
    public class MessageController : ApiController
    {

        private readonly IService<Message> _service;

        public MessageController(IService<Message> service)
        {
            _service = service;
        }

        // GET: api/Message
        public IHttpActionResult Get()
        {
            var entities = this._service.Get();
            var dtos = Mapper.Map<IEnumerable<MessageDto>>(entities);
            return Ok(dtos);
        }

        // GET: api/Message/5
        public IHttpActionResult Get(int id)
        {
            var entity = this._service.Get(id, collections: true);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<MessageDto>(entity);
            return Ok(dto);
        }

        // POST: api/Message
        public IHttpActionResult Post([FromBody]MessageDto value)
        {
            var entity = Mapper.Map<Message>(value);
            entity = this._service.Add(entity);
            value = Mapper.Map<MessageDto>(entity);
            return Ok(value);
        }

        // PUT: api/Message/5
        public IHttpActionResult Put(int id, [FromBody]MessageDto value)
        {
            var entity = Mapper.Map<Message>(value);
            this._service.Change(entity);
            return Ok();
        }

        // DELETE: api/Message/5
        public IHttpActionResult Delete(int id)
        {
            this._service.Remove(id);
            return Ok();
        }
    }
}
