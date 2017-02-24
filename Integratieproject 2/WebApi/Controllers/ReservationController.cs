using System;
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
    [RoutePrefix("api/reservations")]
    public class ReservationController : ApiController
    {
        private readonly IService<Branch> _branchService;
        private readonly IService<City> _cityService;
        private readonly IService<Space> _spaceService;
        private readonly IService<Reservation> _reservationService;

        public ReservationController(IService<Branch> service, IService<City> cityService, IService<Space> spaceService, IService<Reservation> reservationService )
        {
            _branchService = service;
            _cityService = cityService;
            _spaceService = spaceService;
            _reservationService = reservationService;
        }

        [Route("available/{postalcode}")]
        [HttpGet]
        public IHttpActionResult IsPlaceInBranches(int postalcode, [FromUri] AvailableBranchUri parameters)
        {
            var postalString = postalcode.ToString();

            var cities = _cityService.Get(e => e.PostalCode == postalString).ToList();
            if (!cities.Any())
            {
                return NotFound();
            }
            var citiesId = cities.Select(city => city.Id).ToList();
            var entities = this._branchService.Get(b => citiesId.Contains(b.CityId), collections: true).AsEnumerable();

            var branches = new List<CheckBranchDto>();
            var date = new DateTime(parameters.DateTime.Year, parameters.DateTime.Month, parameters.DateTime.Day, parameters.DateTime.Hour, parameters.DateTime.Minute, 0);
            foreach (var entity in entities)
            {
                var branch = Mapper.Map<CheckBranchDto>(entity);
                var operationHour = entity.OpeningHours.FirstOrDefault(e => e.Day == date.DayOfWeek);
                if (operationHour == null)
                {
                    branch.Available = false;
                    branch.Message = CheckMessage.Closed;
                    branches.Add(branch);
                    continue;
                }
                if (!operationHour.IsOpen(date.Hour, date.Minute))
                {
                    branch.Available = false;
                    branch.Message = CheckMessage.Closed;
                    branches.Add(branch);
                    continue;
                }
                var roomIds = entity.Rooms.Select(room => room.Id).ToList();
                var spaces = _spaceService.Get(e => roomIds.Contains(e.RoomId), e => (e.MinPersons <= parameters.Amount && e.Persons <= parameters.Amount), collections: true).ToList();


                var freeSpaces = new List<Space>();
                foreach (var space in spaces)
                {
                    //MAX HOURS?
                    var reservations =
                        space.Reservations.Where(
                            e =>
                                e.DateTime.Year == date.Year && e.DateTime.Month == date.Month &&
                                e.DateTime.Day == date.Day && e.DateTime.Hour < date.Hour + 3).ToList();

                    var isAvailable = true;
                    foreach (var reservation in reservations)
                    {
                        var dateTimeRes = reservation.DateTime;
                        var dateEndTimeRes = reservation.EndDateTime;
                        //if (hours < 0 || hours > 23) throw bad

                        if (date.TimeOfDay > dateTimeRes.TimeOfDay && date.TimeOfDay < dateEndTimeRes.TimeOfDay)
                        {
                            isAvailable = false;
                        }
                        else if ((date.AddHours(2)).TimeOfDay > dateTimeRes.TimeOfDay &&
                                 (date.AddHours(2)).TimeOfDay < dateEndTimeRes.TimeOfDay)
                        {
                            isAvailable = false;
                        }
                    }
                    if (isAvailable)
                    {
                        freeSpaces.Add(space);
                    }

                }
                if (freeSpaces.Any())
                {
                    branch.Available = true;
                    branch.Message = CheckMessage.Free;

                }
                else
                {
                    branch.Available = false;
                    branch.Message = CheckMessage.Full;
                }
                branches.Add(branch);

            }


            return Ok(branches);
        }

        [Route("{branchId}")]
        [HttpGet]
        public IHttpActionResult IsPlaceInBranch(int branchId, [FromUri] AvailableBranchUri parameters)
        {
            var date = new DateTime(parameters.DateTime.Year, parameters.DateTime.Month, parameters.DateTime.Day, parameters.DateTime.Hour, parameters.DateTime.Minute, 0);
            var entity = _branchService.Get(branchId);
                var branch = Mapper.Map<CheckBranchDto>(entity);
                var operationHour = entity.OpeningHours.FirstOrDefault(e => e.Day == date.DayOfWeek);
                if (operationHour == null)
                {
                    branch.Available = false;
                    branch.Message = CheckMessage.Closed;
                return Ok(branch);
                }
                if (!operationHour.IsOpen(date.Hour, date.Minute))
                {
                    branch.Available = false;
                    branch.Message = CheckMessage.Closed;
                return Ok(branch);
                }
                var roomIds = entity.Rooms.Select(room => room.Id).ToList();
                var spaces = _spaceService.Get(e => roomIds.Contains(e.RoomId), e => (e.MinPersons <= parameters.Amount && e.Persons <= parameters.Amount), collections: true);


                var freeSpaces = new List<Space>();
                foreach (var space in spaces)
                {
                    //MAX HOURS?
                    var reservations =
                        space.Reservations.Where(
                            e =>
                                e.DateTime.Year == date.Year && e.DateTime.Month == date.Month &&
                                e.DateTime.Day == date.Day && e.DateTime.Hour < date.Hour + 3).ToList();

                    var isAvailable = true;
                    foreach (var reservation in reservations)
                    {
                        var dateTimeRes = reservation.DateTime;
                        var dateEndTimeRes = reservation.EndDateTime;
                        //if (hours < 0 || hours > 23) throw bad

                        if (date.TimeOfDay > dateTimeRes.TimeOfDay && date.TimeOfDay < dateEndTimeRes.TimeOfDay)
                        {
                            isAvailable = false;
                        }
                        else if ((date.AddHours(2)).TimeOfDay > dateTimeRes.TimeOfDay &&
                                 (date.AddHours(2)).TimeOfDay < dateEndTimeRes.TimeOfDay)
                        {
                            isAvailable = false;
                        }
                    }
                    if (isAvailable)
                    {
                        freeSpaces.Add(space);
                    }

                }
                if (freeSpaces.Any())
                {
                    branch.Available = true;
                    branch.Message = CheckMessage.Free;

                }
                else
                {
                    branch.Available = false;
                    branch.Message = CheckMessage.Full;
                }

            


            return Ok(branch);
        }

        [Route("")]
        [Authorize]
        [HttpPost]
        public IHttpActionResult ReserveSpace([FromBody] NewReservationDto reservation)
        {
            //Check modal
            var branch = _branchService.Get(reservation.BranchId);
            if (branch == null)
            {
                return BadRequest("Branch not found");
            }

            if (reservation.DateTime < DateTime.Now)
            {
                return BadRequest("Reservation needs to be in future");
            }

            if (reservation.Amount < 1)
            {
                return BadRequest("U need to be with atleast one person..");
            }


            //Logica voor room te vinden..

            var entity = this._branchService.Get(branch.Id,collections:true);
            var date = reservation.DateTime;

            var operationHour = entity.OpeningHours.FirstOrDefault(e => e.Day == date.DayOfWeek);
                if (operationHour == null)
                {
                    return Conflict();
                }
                if (!operationHour.IsOpen(date.Hour, date.Minute))
            {
                return Conflict();
            }
                var roomIds = entity.Rooms.Select(room => room.Id).ToList();
                var spaces = _spaceService.Get(e => roomIds.Contains(e.RoomId), e => (e.MinPersons <= reservation.Amount && e.Persons >= reservation.Amount), collections: true).ToList();

                var freeSpaces = new List<Space>();
                foreach (var space in spaces)
                {
                    //MAX HOURS?
                    var reservations =
                        space.Reservations.Where(
                            e =>
                                e.DateTime.Year == date.Year && e.DateTime.Month == date.Month &&
                                e.DateTime.Day == date.Day && e.DateTime.Hour < date.Hour + 3).ToList();

                    var isAvailable = true;
                    foreach (var res in reservations)
                    {
                        var dateTimeRes = res.DateTime;
                        var dateEndTimeRes = res.EndDateTime;
                        //if (hours < 0 || hours > 23) throw bad

                        if (date.TimeOfDay > dateTimeRes.TimeOfDay && date.TimeOfDay < dateEndTimeRes.TimeOfDay)
                        {
                            isAvailable = false;
                        }
                        else if ((date.AddHours(2)).TimeOfDay > dateTimeRes.TimeOfDay &&
                                 (date.AddHours(2)).TimeOfDay < dateEndTimeRes.TimeOfDay)
                        {
                            isAvailable = false;
                        }
                    }
                    if (isAvailable)
                    {
                        var newReservation = new Reservation()
                        {
                            AccountId = User.Identity.GetUserId(),
                            BranchId = branch.Id,
                            AmountOfPersons = reservation.Amount,
                            DateTime = reservation.DateTime,
                            EndDateTime = reservation.DateTime.AddHours(2),
                            SpaceId = space.Id
                        };

                        newReservation = _reservationService.Add(newReservation);

                        return Ok(newReservation);
                    }

                }
            return BadRequest("No free space.");
        }
    }


}
