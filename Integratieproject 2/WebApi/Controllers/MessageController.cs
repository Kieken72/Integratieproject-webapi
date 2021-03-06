﻿using System;
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
    [RoutePrefix("api/messages")]
    public class MessageController : ApiController
    {
        private readonly IService<Message> _service;

        public MessageController(IService<Message> service)
        {
            _service = service;
        }

        [Route("{id}")]
        [Authorize]
        // GET: api/Message/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = this._service.Get(e => e.ReservationId == id, collections: true);
                if (!entity.Any())
                {
                    return NotFound();
                }
                var dto = Mapper.Map<IEnumerable<MessageDto>>(entity);
                return Ok(dto);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [Route("by-branch/{id}")]
        [Authorize(Roles = "Manager")]
        // GET: api/Message/5
        public IHttpActionResult GetByBranch(int id)
        {
            var entity = this._service.Get(e => e.BranchId == id, collections: true);
            if (!entity.Any())
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<MessageDto>>(entity);
            return Ok(dto);
        }

        // POST: api/Message
        [Route("")]
        [Authorize]
        public IHttpActionResult Post([FromBody]MessageDto value)
        {
            value.UserId = User.Identity.GetUserId();
            var entity = Mapper.Map<Message>(value);
            entity.DateTime = DateTime.Now;
            entity = this._service.Add(entity);
            value = Mapper.Map<MessageDto>(entity);
            return Ok(value);
        }
    }
}
