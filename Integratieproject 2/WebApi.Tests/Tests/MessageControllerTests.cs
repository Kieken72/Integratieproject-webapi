using System.Collections.Generic;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests.Tests
{
    public class MessageControllerTests
    {
        private MessageController _controller;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MessageProfile>();
            });
            _controller = new MessageController(new MessageService());
        }


        [Test]
        public void Get_MessagesById()
        {
            var cResult = _controller.Get(1);
            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<MessageDto>>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<IEnumerable<MessageDto>>>(rResult);

        }

        [Test]
        public void Get_MessagesByBranch()
        {
            var cResult = _controller.GetByBranch(1);
            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<MessageDto>>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<IEnumerable<MessageDto>>>(rResult);

        }

    }
}
