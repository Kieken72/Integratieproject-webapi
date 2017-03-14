using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Controllers.Account;

namespace WebApi.Tests.Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        private AccountsController _controller;


        [SetUp]
        public void SetUp()
        {
            _controller = new AccountsController(new BranchService());



        }

        //Testen met OWIN werken niet! (Owin wordt niet geladen in testomgeving..)
    }
}
