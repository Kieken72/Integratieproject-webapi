using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        private AccountsController _controller;


        [SetUp]
        public void SetUp()
        {
            _controller = new AccountsController();



        }
        [Test]
        public void Post_CreateUser()
        {

            var accountModel = new CreateUserBindingModel()
            {
                Email = "Test@test.be",
                FirstName = "test",
                LastName = "Test",
                ConfirmPassword = "MyVeryStrongPassword123$",
                Password = "MyVeryStrongPassword123$"
            };

            var cResult = _controller.CreateUser(accountModel);
            Assert.IsNotNull(cResult);
            //OWIN WORDT NIET GELADEN IN TESTS


            //var rResult = cResult as CreatedNegotiatedContentResult<UserReturnModel>;
            //Assert.IsNotEmpty(rResult.Content);
        }
        

    }
}
