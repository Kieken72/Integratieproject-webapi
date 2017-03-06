using System.Collections.Generic;

namespace Leisurebooker.Business.Domain
{
    public class Space : Entity
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }


        public SpaceType Type { get; set; }

        public int Persons { get; set; }
        public int MinPersons { get; set; }

        public int RoomId { get; set; }

        //Location in room

        public int X { get; set; }
        public int Y { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public Space()
        {
            Type = SpaceType.Bowling;
            Enabled = true;
        }
    }
}