﻿using System.Collections.Generic;
using System.Web.Http.Results;
using AutoMapper;
using Leisurebooker.Business.Services;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi.Tests.Tests
{
    [TestFixture()]
    public class BranchControllerTests
    {
        private BranchController _controller;
        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BranchProfile>();
                cfg.AddProfile<CityProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<OpeningHourProfile>();
                cfg.AddProfile<AdditionalInfoProfile>();
            });
            _controller = new BranchController(new BranchService(), new CityService(), new SpaceService(), new RoomService(), new AdditionalInfoService(), new OperationHourService(), new ReservationService());
        }
        [Test]
        public void Get_ReturnsMultipleBranches()
        {

            var cResult = _controller.Get();
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<BranchDto>>;
            Assert.IsNotEmpty(rResult.Content);
        }

        [Test]
        public void GetByPostalCode_CorrectPostalCodeWillGetBranchesEntityAndOkResult()
        {
            var cResult = _controller.GetByPostalCode(2000);
            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<BranchDto>>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<IEnumerable<BranchDto>>>(cResult);
        }
        
        [Test]
        public void Get_CorrectIdWillGetBranchEntityAndOkResult()
        {
            var cResult = _controller.Get(1);
            var rResult = cResult as OkNegotiatedContentResult<BranchDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<BranchDto>>(cResult);
        }

        [Test]
        public void Get_WrongIdWillGetNotFoundResult()
        {
            var cResult = _controller.Get(0);
            var rResult = cResult as NotFoundResult;
            Assert.IsInstanceOf<NotFoundResult>(rResult);

        }

        [Test]
        public void Post_AddNewBranchToDatabase()
        {
            var entity = new BranchDto()
            {
                Name = "Super Bowl",
                Street = "Groenplaats",
                Number = "1",
                CityId = 1,
                Email = "test@test.be",
                CompanyId = 1,
                Description = "Lorem ipsum",
                PhoneNumber = "032222222",
            };

            var cResult = _controller.Post(entity);
            var rResult = cResult as OkNegotiatedContentResult<BranchDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<BranchDto>>(cResult);
            Assert.AreEqual(entity.Name, rResult.Content.Name);
        }

        [Test]
        public void Put_UpdateBranchToDatabase()
        {
            var bResult = _controller.Get(1);
            var rResult = bResult as OkNegotiatedContentResult<BranchDto>;
            var b = rResult.Content;
            b.Name = "Update";
            var cResult = _controller.Put(b.Id,b);
            Assert.IsInstanceOf<OkResult>(cResult);
        }

        [Test]
        public void Get_WillReturnRoomOfBranch()
        {
            var entity = new BranchDto()
            {
                Name = "Super Bowl",
                Street = "Groenplaats",
                Number = "1",
                CityId = 1,
                Email = "test@test.be",
                CompanyId = 1,
                Description = "Lorem ipsum",
                PhoneNumber = "032222222",
            };

            var cResult = _controller.Post(entity);
            var rResult = cResult as OkNegotiatedContentResult<BranchDto>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<BranchDto>>(rResult);
            var tempResult =
                _controller.NewRoom(new RoomDto()
                {
                    BranchId = rResult.Content.Id,
                    Height = 500,
                    Enabled = true,
                    Width = 500,
                    Name = "Baan 1"
                });
            var tempRResult = tempResult as OkNegotiatedContentResult<RoomDto>;

            Assert.IsInstanceOf<OkNegotiatedContentResult<RoomDto>>(tempRResult);
            var finalResult = _controller.GetRoom(tempRResult.Content.Id);
            var finalRResult = finalResult as OkNegotiatedContentResult<RoomDto>;

            Assert.IsInstanceOf<OkNegotiatedContentResult<RoomDto>>(finalRResult);
            Assert.AreEqual(tempRResult.Content.Id,finalRResult.Content.Id);


        }

        [Test]
        public void Get_Guests()
        {
            var entity = new BranchDto()
            {
                Name = "Super Bowl",
                Street = "Groenplaats",
                Number = "1",
                CityId = 1,
                Email = "test@test.be",
                CompanyId = 1,
                Description = "Lorem ipsum",
                PhoneNumber = "032222222",
            };

            var cResult = _controller.Post(entity);
            cResult = _controller.GetGuests((cResult as OkNegotiatedContentResult<BranchDto>).Content.Id);
            Assert.IsNotNull(cResult);

            var rResult = cResult as OkNegotiatedContentResult<IEnumerable<FullAccountDto>>;
            Assert.IsInstanceOf<OkNegotiatedContentResult<IEnumerable<FullAccountDto>>>(rResult);
        }
        [Test]
        public void Delete_BadRequest()
        {
            var cResult = _controller.Delete(1);
            Assert.IsInstanceOf<OkResult>(cResult);
        }

    }
}
