using NUnit.Framework;
using WebApi.Controllers;

namespace WebApi.Tests.Tests
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

        //Testen met OWIN werken niet! (Owin wordt niet geladen in testomgeving..)
    }
}
