using System;
using System.Collections;
using System.Collections.Generic;

namespace Leisurebooker.Business.Domain
{
    public class Reservation : Entity
    {
        public int AmountOfPersons { get; set; }
        public DateTime DateTime { get; set; }

        //vermoedelijke einddatum?


        public int SpaceId { get; set; }
        public int BranchId { get; set; }

        public int UserId { get; set; }

        public ICollection<Message> Messages { get; set; }
        public Review Review { get; set; }

            //welke zaal
        //welke tafel koppelt backend..?

        //Wie heeft reservatie gemaakt

        //Gast

        
        public bool Cancelled { get; set; }
    }
}