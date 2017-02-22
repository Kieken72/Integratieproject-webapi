using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("api/reservations")]
    public class ReservationController : ApiController
    {
        private readonly IService<Branch> _service;
        private readonly IService<City> _cityService;
        private readonly IService<Space> _spaceService;
        private readonly IService<Reservation> _reservationService;

        public ReservationController(IService<Branch> service, IService<City> cityService, IService<Space> spaceService, IService<Reservation> reservationService )
        {
            _service = service;
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
            var entities = this._service.Get(b => citiesId.Contains(b.CityId), collections: true).AsEnumerable();

            var branches = new List<CheckBranchDto>();
            var date = new DateTime(parameters.Year, parameters.Month, parameters.Day, parameters.Hours, parameters.Minutes, 0);
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
                branches.Add(branch);

            }


            return Ok(branches);
        }
    }
}
