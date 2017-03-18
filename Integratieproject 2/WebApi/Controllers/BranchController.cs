using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using WebApi.Models;
using WebApi.Models.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("api/branches")]
    public class BranchController : ApiController
    {
        private readonly IService<Branch> _service;
        private readonly IService<City> _cityService;
        private readonly IService<Space> _spaceService;
        private readonly IService<Room> _roomService;
        private readonly IService<AdditionalInfo> _additionalInfoService;
        private readonly IService<OperationHours> _operationHoursService;
        private readonly IService<Reservation> _reservationService;

        public BranchController(IService<Branch> service, 
            IService<City> cityService, 
            IService<Space> spaceService, 
            IService<Room> roomService,
            IService<AdditionalInfo> additionalInfoService,
            IService<OperationHours> operationHoursService,
            IService<Reservation> reservationService)
        {
            _service = service;
            _cityService = cityService;
            _spaceService = spaceService;
            _roomService = roomService;
            _operationHoursService = operationHoursService;
            _additionalInfoService = additionalInfoService;
            _reservationService = reservationService;
        }

        [Route("")]
        // GET: api/branches
        public IHttpActionResult Get()
        {
            var entities = this._service.Get();
            var dtos = Mapper.Map<IEnumerable<BranchDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        // GET: api/branches/5
        public IHttpActionResult Get(int id)
        {
            var entity = this._service.Get(id, collections: true);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<BranchDto>(entity);
            dto.Reviews = dto.Reviews.Where(e => e.Public).ToList();
            return Ok(dto);
        }

        [Route("by-postal/{postalcode}")]
        public IHttpActionResult GetByPostalCode(int postalcode)
        {
            var postalString = postalcode.ToString();

            var cities = _cityService.Get(e => e.PostalCode == postalString).ToList();
            if (!cities.Any())
            {
                return NotFound();
            }
            var citiesId = cities.Select(city => city.Id).ToList();

            var entities = this._service.Get(b=>citiesId.Contains(b.CityId)).AsEnumerable();

            var dto = Mapper.Map<IEnumerable<BranchDto>>(entities);
            return Ok(dto);
        }

        


        [Route("")]
        [Authorize(Roles = "Owner")]
        //!!Authorized as manager from company
        // POST: api/branches
        public IHttpActionResult Post([FromBody]BranchDto value)
        {
            var entity = Mapper.Map<Branch>(value);
            entity = this._service.Add(entity);
            value = Mapper.Map<BranchDto>(entity);
            return Ok(value);

        }

        [Route("room")]
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public IHttpActionResult NewRoom([FromBody] RoomDto value)
        {
            var entity = Mapper.Map<Room>(value);
            entity = this._roomService.Add(entity);
            value = Mapper.Map<RoomDto>(entity);
            return Ok(value);
        }
        [Route("room/{id}")]
        [Authorize(Roles = "Manager")]
        [HttpPut]
        public IHttpActionResult EditRoom(int id,[FromBody] RoomDto value)
        {

            var entity = Mapper.Map<Room>(value);
            this._roomService.Change(entity);
            //value = Mapper.Map<RoomDto>(entity);
            return Ok();
        }
        [Route("room/{id}")]
        [HttpGet]
        public IHttpActionResult GetRoom(int id)
        {
            var entity = _roomService.Get(id, true);
            if (entity == null) return NotFound();
            var dto = Mapper.Map<RoomDto>(entity);
            return Ok(dto);
        }

        [Route("space")]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult NewSpace([FromBody] SpaceDto value)
        {
            var entity = Mapper.Map<Space>(value);
            entity = this._spaceService.Add(entity);
            value = Mapper.Map<SpaceDto>(entity);
            return Ok(value);
        }

        [Route("space/{id}")]
        [HttpPut]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult EditSpace(int id, [FromBody] SpaceDto value)
        {

            var space = this._spaceService.Get(id);
            space.Name = value.Name;
            space.Enabled = value.Enabled;
            space.MinPersons = value.MinPersons;
            space.Persons = value.Persons;
            space.Type = value.Type;
            space.X = value.X;
            space.Y = value.Y;
            //var entity = Mapper.Map<Space>(value);
            this._spaceService.Change(space);
            //value = Mapper.Map<RoomDto>(entity);
            return Ok();
        }




        [Route("operationhours/{id}")]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult OperationHours(int id, [FromBody] IEnumerable<OperationHoursDto> values)
        {
            var branch = _service.Get(id, collections: true);
            if (branch == null)
            {
                return NotFound();
            }
            var openingId = branch.OpeningHours.Select(e => e.Id).ToList();
            foreach (var f in openingId)
            {
                _operationHoursService.Remove(f);   
            }
            var entities = Mapper.Map<IEnumerable<OperationHours>>(values);
            foreach (var entity in entities)
            {
                entity.BranchId = branch.Id;
                _operationHoursService.Add(entity);
            }
            return Ok();
        }

        [Route("additionalinfo/{id}")]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult AdditionalInfo(int id, [FromBody] IEnumerable<AdditionalInfoDto> values)
        {
            var branch = _service.Get(id, collections: true);
            if (branch == null)
            {
                return NotFound();
            }
            var addInfoId = branch.AdditionalInfos.Select(e => e.Id).ToList();
            foreach (var f in addInfoId)
            {
                _additionalInfoService.Remove(f);
            }
            var entities = Mapper.Map<IEnumerable<AdditionalInfo>>(values);
            foreach (var entity in entities)
            {
                entity.BranchId = branch.Id;
                _additionalInfoService.Add(entity);
            }
            return Ok();
        }

        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        //!!Authorized as manager from this company
        // PUT: api/branches/5
        public IHttpActionResult Put(int id, [FromBody]BranchDto value)
        {
            var branch = _service.Get(id);
            branch.Name = value.Name;
            branch.Description = value.Description;
            branch.Email = value.Email;
            branch.PhoneNumber = value.PhoneNumber;
            branch.Street = value.Street;
            branch.Number = value.Number;
            branch.Box = value.Box;
            branch.CityId = value.CityId;

            this._service.Change(branch);
            return Ok();
        }

        public IHttpActionResult PutBranchImage(int id)
        {
            if (!HttpContext.Current.Request.Files.AllKeys.Any()) return Ok("Image is not Uploaded");
            // Get the uploaded image from the Files collection  
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            if (httpPostedFile == null) return Ok("Image is not Uploaded");
            var imgupload = new FileUpload();
            int length = httpPostedFile.ContentLength;
            imgupload.Imagedata = new byte[length]; //get imagedata  
            httpPostedFile.InputStream.Read(imgupload.Imagedata, 0, length);
            imgupload.Imagename = Path.GetFileName(httpPostedFile.FileName);
            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content"), httpPostedFile.FileName);
            httpPostedFile.SaveAs(fileSavePath);
            var branch = _service.Get(id);
            branch.Picture = $"Content/{imgupload.Imagename}";
            _service.Change(branch);
            return Ok("Image Uploaded");
        }
        

        [Route("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        //!!Authorized only as admin
        // DELETE: api/branches/5
        public IHttpActionResult Delete(int id)
        {
            this._service.Remove(id);
            return Ok();
        }

        [Route("guests/{id}")]
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult GetGuests(int id)
        {
            var guests = _reservationService.Get(e => e.BranchId == id).Select(e => e.User).Distinct().ToList();
            var dto = Mapper.Map<IEnumerable<FullAccountDto>>(guests);
            return Ok(dto);
        }
        



    }
}
