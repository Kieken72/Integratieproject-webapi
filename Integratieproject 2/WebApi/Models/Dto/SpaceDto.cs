using System.Collections.Generic;

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

        //TO ADD POSITIONS
        public ICollection<ReservationDto> Reservations { get; set; }
    }
}