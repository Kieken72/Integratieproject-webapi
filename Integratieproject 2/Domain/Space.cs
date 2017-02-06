using System.Collections.Generic;

namespace Leisurebooker.Business.Domain
{
    public class Space : Entity
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        //Iets voor type te bepalen

        public int Persons { get; set; }
        public int MinPersons { get; set; }

        public int RoomId { get; set; }

        public ICollection<Reservation> Reservations { get; set; }  
    }
}