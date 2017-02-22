using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using NUnit.Framework;

namespace Leisurebooker.Business.Tests.Services
{
    [TestFixture]
    public class AuthServiceTests
    {
        private AuthService _authService;

        private Account _account;

        [SetUp]
        public void SetUp()
        {
            _authService = new AuthService();

            //NO REFERENCE!!

            //_account =  new Account()
            //{
            //    UserName = "NewAccount@test.be",
            //    Email = "NewAccount@test.be",
            //    Name = "New",
            //    Surname = "AfterNew",
            //};

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var user = new Account()
            //{
            //    UserName = createUserModel.Username,
            //    Email = createUserModel.Email,
            //    Name = createUserModel.FirstName,
            //    Surname = createUserModel.LastName,
            //};

            //IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

            //if (!addUserResult.Succeeded)
            //{
            //    return GetErrorResult(addUserResult);
            //}

            //string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

            //var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

            //await this.AppUserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            //Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            //return Created(locationHeader, TheModelFactory.Create(user));
        }


    }
}
