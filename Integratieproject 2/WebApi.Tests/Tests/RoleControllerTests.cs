using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers.Account;

namespace WebApi.Tests.Tests
{
    [TestFixture]
    public class RoleControllerTests
    {
        private RolesController _controller;


        [SetUp]
        public void SetUp()
        {
            _controller = new RolesController(new BranchService());



        }

        //Testen met OWIN werken niet! (Owin wordt niet geladen in testomgeving..)
    }
}
