using System.Collections.Generic;
using Leisurebooker.Business.Domain;

namespace WebApi.Models.Dto
{
    public class SpaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int Persons { get; set; }
        public int MinPersons { get; set; }
        public int RoomId { get; set; }


        public int X { get; set; }
        public int Y { get; set; }
        public SpaceType Type { get; set; }
        public ICollection<ReservationDto> Reservations { get; set; }
    }
}