﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Itenso.TimePeriod;
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
            if (date < DateTime.Now)
            {
                return BadRequest("Reservation needs to be in future");
            }
            foreach (var entity in entities)
            {
                var branch = Mapper.Map<CheckBranchDto>(entity);
                var operationHour = entity.OpeningHours.Where(e => e.Day == date.DayOfWeek);

                //Openingsuren
                if (!IsValidReservation(operationHour.ToArray(), parameters.DateTime, parameters.DateTime.AddHours(2)))
                {
                    branch.Available = false;
                    branch.Message = CheckMessage.Closed;
                    return Ok(branch);
                }
                var roomIds = entity.Rooms.Select(room => room.Id).ToList();
                var spaces = _spaceService.Get(e => roomIds.Contains(e.RoomId), e => (e.MinPersons <= parameters.Amount && e.Persons >= parameters.Amount), collections: true).ToList();


                var freeSpaces = new List<Space>();
                foreach (var space in spaces)
                {
                    //MAX HOURS?
                    var reservations =
                    space.Reservations.Where(e => e.DateTime.Date == date.Date).ToList();



                    var isAvailable = DoesNotOverlap(reservations.ToArray(), date, date.AddHours(2));

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
            if (date < DateTime.Now)
            {
                return BadRequest("Reservation needs to be in future");
            }

            var entity = _branchService.Get(branchId, collections:true);
                var branch = Mapper.Map<CheckBranchDto>(entity);
            var operationHour = entity.OpeningHours.Where(e => e.Day == date.DayOfWeek);

            //Openingsuren
            if (!IsValidReservation(operationHour.ToArray(), parameters.DateTime, parameters.DateTime.AddHours(2)))
            {
                branch.Available = false;
                branch.Message = CheckMessage.Closed;
                return Ok(branch);
            }
                var roomIds = entity.Rooms.Select(room => room.Id).ToList();
                var spaces = _spaceService.Get(e => roomIds.Contains(e.RoomId), e => (e.MinPersons <= parameters.Amount && e.Persons >= parameters.Amount), collections: true).ToList();


                var freeSpaces = new List<Space>();
                foreach (var space in spaces)
                {
                //MAX HOURS?
                var reservations =
                    space.Reservations.Where(e => e.DateTime.Date == date.Date).ToList();



                var isAvailable = DoesNotOverlap(reservations.ToArray(), date, date.AddHours(2));
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

            var operationHour = entity.OpeningHours.Where(e => e.Day == date.DayOfWeek);
            
            //Openingsuren
            if (!IsValidReservation(operationHour.ToArray(), reservation.DateTime, reservation.DateTime.AddHours(2)))
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.PreconditionFailed));
            }


                var roomIds = entity.Rooms.Select(room => room.Id).ToList();
                var spaces = _spaceService.Get(e => roomIds.Contains(e.RoomId), e => (e.MinPersons <= reservation.Amount && e.Persons >= reservation.Amount), collections: true).ToList();

                foreach (var space in spaces)
                {
                    //MAX HOURS?
                    var reservations =
                        space.Reservations.Where(e => e.DateTime.Date == date.Date).ToList();

                

                    var isAvailable = DoesNotOverlap(reservations.ToArray(), date, date.AddHours(2));

                    if (!isAvailable) continue;
                    var newReservation = new Reservation()
                    {
                        UserId = User.Identity.GetUserId(),
                        BranchId = branch.Id,
                        AmountOfPersons = reservation.Amount,
                        DateTime = reservation.DateTime,
                        EndDateTime = reservation.DateTime.AddHours(2),
                        SpaceId = space.Id
                    };

                    newReservation = _reservationService.Add(newReservation);

                    //SendMail!!
                    return Ok(newReservation);
                }
            return BadRequest("No free space.");
        }

        [Route("branch/{id}")]
        [HttpGet]
        public IHttpActionResult ForBranch(int id)
        {
            var entities = this._reservationService.Get(e=>e.BranchId==id, e=>e.DateTime > (DateTime.Today.AddDays(-1)));
            var dtos = Mapper.Map<IEnumerable<ReservationDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        [Authorize]
        [HttpDelete]
        public IHttpActionResult CancelReservation(int id)
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();
            var res = _reservationService.Get(id);
            if (res == null)
            {
                return NotFound();
            }
            if (res.UserId != User.Identity.GetUserId()) return Unauthorized();
            if (res.DateTime < DateTime.Now) return BadRequest();
                res.Cancelled = true;
            _reservationService.Change(res);
            return Ok();
        }



        public static bool IsValidReservation(OperationHours[] operationHours,DateTime start, DateTime end)
        {
            if (!TimeCompare.IsSameDay(start, end))
            {
                return false;
            }
            if (operationHours == null)
            {
                return false;
            }

            var isValid = false;
            foreach (var operationHour in operationHours)
            {
                if (isValid) continue;
                var workingHours = new TimeRange(TimeTrim.Hour(start, operationHour.FromTime.Hours, operationHour.FromTime.Minutes), TimeTrim.Hour(start, operationHour.ToTime.Hours, operationHour.ToTime.Minutes));
                isValid = workingHours.HasInside(new TimeRange(start, end));
            }

            
            return isValid;
        }

        public static bool DoesNotOverlap(Reservation reservation, DateTime start, DateTime end)
        {
            if (reservation == null)
            {
                return false;
            }

            var workingHours = new TimeRange(
                TimeTrim.Hour(start,reservation.DateTime.Hour, reservation.DateTime.Minute),
                TimeTrim.Hour(start, reservation.EndDateTime.Hour, reservation.EndDateTime.Minute));

            return workingHours.IntersectsWith(new TimeRange(start, end));
        }

        public static bool DoesNotOverlap(Reservation[] reservations, DateTime start, DateTime end)
        {
            var isValid = false;
            foreach (var reservation in reservations)
            {
                if (isValid)
                {
                    return false;
                }
                isValid = DoesNotOverlap(reservation, start, end);
            }
            return !isValid;

        }



    }


}
