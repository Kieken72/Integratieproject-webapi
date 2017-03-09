using AutoMapper;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
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

    }
}
